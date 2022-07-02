package main

import (
	"github.com/SyncSoftInc/NinaHome/go/api"
	"github.com/SyncSoftInc/NinaHome/go/core"
	"github.com/syncfuture/go/slog"
)

func main() {
	slog.Init(core.ConfigProvider)

	api.AddClassActions()
	api.AddContactActions()
	api.AddTestimonialActions()
	api.AddAccountActions()
	api.AddUserActions()

	core.Host.ServeFiles("/{filepath:*}", "./wwwroot/")
	slog.Fatal(core.Host.Run())
}
