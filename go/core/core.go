package core

import "github.com/syncfuture/go/sconfig"

var (
	ConfigProvider sconfig.IConfigProvider
)

func init() {
	ConfigProvider = sconfig.NewJsonConfigProvider()
}
