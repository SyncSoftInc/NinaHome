package core

import (
	"fmt"

	"github.com/gorilla/securecookie"
	"github.com/sony/sonyflake"
	"github.com/syncfuture/go/sconfig"
	"github.com/syncfuture/go/ssecurity"
	"github.com/syncfuture/go/u"
	"github.com/syncfuture/host"
	"github.com/syncfuture/host/sfasthttp"
)

const (
	// _saltLength = 32
	_passLength = 64
	COOKIE_KEY  = ".NAUTH"
)

var (
	_idGenerator   *sonyflake.Sonyflake
	ConfigProvider sconfig.IConfigProvider
	Host           host.IWebHost
)

func init() {
	ConfigProvider = sconfig.NewJsonConfigProvider()

	hashKey := ConfigProvider.GetString("HashKey")
	blockKey := ConfigProvider.GetString("BlockKey")

	Host = sfasthttp.NewFHWebHost(ConfigProvider, func(fh *sfasthttp.FHWebHost) {
		scookie := securecookie.New(u.StrToBytes(hashKey), u.StrToBytes(blockKey))
		fh.CookieEncryptor = ssecurity.NewSecureCookieEncryptor(scookie)
	})

	_idGenerator = sonyflake.NewSonyflake(sonyflake.Settings{})
}

// GenerateID _
func GenerateID() string {
	a, _ := _idGenerator.NextID()
	return fmt.Sprintf("%x", a)
}

// HashPassword _
func HashPassword(salt, pass string) string {
	return ssecurity.HashPassword(salt, pass, _passLength)
}
