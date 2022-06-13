package mongo

import (
	"context"

	"github.com/SyncSoftInc/paymentech/pmtcsvc/core"
	"github.com/syncfuture/go/serr"
	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
)

var (
	_connStr string
	dbs      = make(map[string]*mongo.Database)
)

func init() {
	_connStr = core.ConfigProvider.GetString("Mongo.ConnectionString")
}

func dialDB(dbName string) (*mongo.Database, error) {
	// *deprecated
	// connStr := _connStr + "?db=" + dbName
	// db, err := smdb.Dial(connStr)

	client, err := mongo.Connect(context.Background(), options.Client().ApplyURI(_connStr))
	if err != nil {
		return nil, serr.WithStack(err)
	}
	// defer func() {
	// 	if err = client.Disconnect(ctx); err != nil {
	// 		log.Error(err)
	// 	}
	// }()

	db := client.Database(dbName)
	return db, serr.WithStack(err)
}

func getDB(dbName string) (*mongo.Database, error) {
	if db, ok := dbs[dbName]; ok {
		return db, nil
	}

	var err error
	dbs[dbName], err = dialDB(dbName)
	if err != nil {
		return nil, err
	}
	return dbs[dbName], nil
}

func GetCollection(dbName, colName string) (*mongo.Collection, error) {
	db, err := getDB(dbName)
	if err != nil {
		return nil, err
	}

	return db.Collection(colName), nil
}
