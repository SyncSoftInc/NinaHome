package core

import (
	"fmt"

	"github.com/sony/sonyflake"
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
	_idGenerator   *sonyflake.Sonyflake
	ConfigProvider sconfig.IConfigProvider
	Host           host.IWebHost
)

func init() {
	ConfigProvider = sconfig.NewJsonConfigProvider()
	Host = sfasthttp.NewFHWebHost(ConfigProvider)

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
