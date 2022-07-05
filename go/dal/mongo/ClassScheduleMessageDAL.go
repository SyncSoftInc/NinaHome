package mongo

import (
	"context"

	"github.com/SyncSoftInc/NinaHome/go/dto"
	"github.com/syncfuture/go/serr"
	"github.com/syncfuture/go/u"
	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
	"gopkg.in/mgo.v2/bson"
)

type ClassScheduleMessageDAL struct {
	CTX        context.Context
	Collection *mongo.Collection
}

func (x *ClassScheduleMessageDAL) InsertMessage(in *dto.ClassScheduleMessageDTO) error {
	if u.IsMissing(in) {
		return serr.New("Empty document.")
	}

	_, err := x.Collection.InsertOne(x.CTX, in)
	return serr.WithStack(err)
}

func (x *ClassScheduleMessageDAL) DeleteMessage(id string) error {
	if u.IsMissing(id) {
		return serr.New("ID is null.")
	}

	// mid, err := primitive.ObjectIDFromHex(id)
	// if u.LogError(err) {
	// 	return serr.WithStack(err)
	// }

	_, err := x.Collection.DeleteOne(x.CTX, bson.M{"ID": id})
	return serr.WithStack(err)
}

func (x *ClassScheduleMessageDAL) GetMessage(id string) (r *dto.ClassScheduleMessageDTO, err error) {
	r = new(dto.ClassScheduleMessageDTO)
	if u.IsMissing(id) {
		return nil, serr.New("ID is null.")
	}

	err = x.Collection.FindOne(x.CTX, bson.M{"ID": id}).Decode(&r)
	return r, serr.WithStack(err)
}

func (x *ClassScheduleMessageDAL) GetMessages(in *dto.ClassScheduleMessageQuery) (r *dto.ClassScheduleMessagesResult, err error) {
	r = new(dto.ClassScheduleMessagesResult)
	if u.IsMissing(in) {
		return nil, serr.New("Empty query.")
	}

	// filter
	filter := bson.M{}
	if !u.IsMissing(in.Name) {
		filter["Name"] = in.Name
	}
	if !u.IsMissing(in.Email) {
		filter["Email"] = in.Email
	}

	// options
	opts := options.Find().
		SetSort(bson.M{"CreatedOnUtc": -1}).
		SetSkip(int64((in.PageIndex - 1) * in.PageSize)).
		SetLimit(int64(in.PageSize))

	// find
	entries := make([]*dto.ClassScheduleMessageDTO, 0)
	cursor, err := x.Collection.Find(x.CTX, filter, opts)
	if u.LogError(err) {
		return nil, serr.WithStack(err)
	}
	if err = cursor.All(x.CTX, &entries); u.LogError(err) {
		return nil, serr.WithStack(err)
	}

	// total count
	total, err := x.Collection.CountDocuments(x.CTX, filter)
	if u.LogError(err) {
		return nil, serr.WithStack(err)
	}

	r = dto.NewClassScheduleMessagesResult(int(total), in.PageSize, entries)
	return r, serr.WithStack(err)
}
