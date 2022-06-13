package dal

import (
	"context"

	"github.com/SyncSoftInc/NinaHome/go/dal/mongo"
	"github.com/SyncSoftInc/NinaHome/go/dto"
)

type IClassScheduleMessageDAL interface {
	InsertMessage(*dto.ClassScheduleMessageDTO) error
	DeleteMessage(string) error
	GetMessage(string) (*dto.ClassScheduleMessageDTO, error)
	GetMessages(*dto.ClassScheduleMessageQuery) (*dto.ClassScheduleMessagesResult, error)
}

func CreateClassScheduleMessageDAL() IClassScheduleMessageDAL {
	return &mongo.ClassScheduleMessageDAL{CTX: context.Background(), Collection: getCollection("ClassScheduleMessages")}
}
