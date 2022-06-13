package dal

import (
	m "github.com/SyncSoftInc/NinaHome/go/dal/mongo"
	"github.com/syncfuture/go/slog"
	"go.mongodb.org/mongo-driver/mongo"
)

var (
	DB = "NinaHome"
)

func getCollection(colName string) *mongo.Collection {
	collection, err := m.GetCollection(DB, colName)
	if err != nil {
		slog.Error(err)
	}
	return collection
}
