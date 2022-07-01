// Code generated by hero.
// source: D:\Git\SyncSoftInc\NinaHome\go\views\account\login.html
// DO NOT EDIT!
package views

import (
	"bytes"

	"github.com/shiyanhui/hero"
)

func AccountLoginView(model *map[string]interface{}, buffer *bytes.Buffer) {
	buffer.WriteString(`
<style>
    .login {
        min-height: 100vh;
        display: flex;
        align-items: center;
    }
</style>
`)

	loginErr, _ := (*model)["LoginErr"].(string)
	returnURL, _ := (*model)["ReturnURL"].(string)

	buffer.WriteString(`
<form class="form-signin" action="/account/login?returnUrl=`)
	buffer.WriteString(returnURL)
	buffer.WriteString(`" method="post">
    <div class=" login">
        <div class="container">
            <div class="col-md-5 mx-auto jumbotron">
                <h1 class="text-center">Sign In</h1>
                <form class="form-signin">
                    <div class="form-group">
                        <label>Username</label>
                        <input type="text" name="Username" class="form-control" placeholder="Username" required autofocus />
                    </div>
                    <div class="form-group">
                        <label>Password</label>
                        <input type="password" name="Password" class="form-control" placeholder="Password" required />
                    </div>
                    <div class="form-group">
                        <label class="checkbox-inline"><input type="checkbox" name="RememberMe" value="true" /> Remember me</label>
                    </div>
                    <div class="form-group">
                        <label>
                        `)
	if loginErr != "" {
		buffer.WriteString(`
                        <div class="error">`)
		hero.EscapeHTML(loginErr, buffer)
		buffer.WriteString(`</div>
                        `)
	}
	buffer.WriteString(`
                        </label>
                    </div>
                    <div class="form-group">
                        <button class="btn btn-primary float-right" type="submit">Login</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</form>
`)

}