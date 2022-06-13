package dal

import (
	"context"

	"github.com/SyncSoftInc/NinaHome/go/dal/mongo"
	"github.com/SyncSoftInc/NinaHome/go/dto"
)

type IContactMessageDAL interface {
	InsertMessage(*dto.ContactMessageDTO) error
	DeleteMessage(string) error
	GetMessage(string) (*dto.ContactMessageDTO, error)
	GetMessages(*dto.ContactMessageQuery) (*dto.ContactMessagesResult, error)
}

func CreateContactMessageDAL() IContactMessageDAL {
	return &mongo.ContactMessageDAL{CTX: context.Background(), Collection: getCollection("ContactMessages")}
}
