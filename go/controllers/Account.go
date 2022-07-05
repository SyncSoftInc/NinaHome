package controllers

import (
	"net/http"
	"net/url"
	"strconv"
	"time"

	oauth2 "github.com/Lukiya/oauth2go/core"
	"github.com/SyncSoftInc/NinaHome/go/core"
	"github.com/SyncSoftInc/NinaHome/go/views"
	"github.com/syncfuture/armos/go/user/protoc/user"
	"github.com/syncfuture/go/serr"
	"github.com/syncfuture/go/u"
	"github.com/syncfuture/host"
)

func AddAccountActions() {
	core.Host.POST("/account/login", postLogin)
	core.Host.GET("/account/login", getLogin)
}

func getLogin(ctx host.IHttpContext) {
	returnURL := ctx.GetFormString(oauth2.Form_ReturnUrl)
	if returnURL == "" {
		returnURL = "/"
	}

	model := views.GetModel()
	(*model)["ReturnURL"] = url.QueryEscape(returnURL)
	views.Render(ctx, views.AccountLoginView, model)
}

func postLogin(ctx host.IHttpContext) {
	username := ctx.GetFormString("Username")
	password := ctx.GetFormString("Password")
	rememberMe, _ := strconv.ParseBool(ctx.GetFormString("RememberMe"))
	returnURL := ctx.GetFormString(oauth2.Form_ReturnUrl)
	if returnURL == "" {
		returnURL = "/"
	}

	model := views.GetModel()
	(*model)["ReturnURL"] = returnURL

	users := make([]*user.UserDTO, 0)
	if err := core.ConfigProvider.GetStruct("Users", &users); u.LogError(err) {
		(*model)["LoginErr"] = serr.Cause(err).Error()
		views.Render(ctx, views.AccountLoginView, model)
		return
	}
	// ^^^^^^^^^^

	// check username
	var user *user.UserDTO
	for _, u := range users {
		if u.Username == username {
			user = u
		}
	}
	if u.IsMissing(user) {
		(*model)["LoginErr"] = serr.Cause(serr.New("Incorrect username!")).Error()
		views.Render(ctx, views.AccountLoginView, model)
		return
	}
	// ^^^^^^^^^^

	// check password
	hashpassword := core.HashPassword(user.PasswordSalt, password)
	if user.Password != hashpassword {
		(*model)["LoginErr"] = serr.Cause(serr.New("Incorrect password!")).Error()
		views.Render(ctx, views.AccountLoginView, model)
		return
	}
	// ^^^^^^^^^^

	// login success, set login cookie
	if rememberMe {
		ctx.SetEncryptedCookieKV(core.COOKIE_KEY, user.Username, func(c *http.Cookie) {
			c.Path = "/"
			c.HttpOnly = true
			c.Secure = true
			c.Expires = time.Now().Add(24 * time.Hour * 14)
		})
	} else {
		ctx.SetEncryptedCookieKV(core.COOKIE_KEY, user.Username, func(c *http.Cookie) {
			c.Path = "/"
			c.HttpOnly = true
			c.Secure = true
		})
	}

	ctx.Redirect(returnURL, http.StatusFound)
	views.Render(ctx, views.AccountLoginView, model)
	return
}
