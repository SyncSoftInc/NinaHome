package core

import (
	"github.com/syncfuture/go/sconfig"
	"github.com/syncfuture/go/ssecurity"
	"github.com/syncfuture/host"
	"github.com/syncfuture/host/sfasthttp"
)

const (
	// _saltLength = 32
	_passLength = 64
)

var (
	ConfigProvider sconfig.IConfigProvider
	Host           host.IWebHost
)

func init() {
	ConfigProvider = sconfig.NewJsonConfigProvider()
	Host = sfasthttp.NewFHWebHost(ConfigProvider)
}

// HashPassword _
func HashPassword(salt, pass string) string {
	return ssecurity.HashPassword(salt, pass, _passLength)
}
