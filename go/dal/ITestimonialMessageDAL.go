package dal

import (
	"context"

	"github.com/SyncSoftInc/NinaHome/go/dal/mongo"
	"github.com/SyncSoftInc/NinaHome/go/dto"
)

type ITestimonialMessageDAL interface {
	InsertMessage(*dto.TestimonialMessageDTO) error
	ApproveMessage(string, bool) error
	DeleteMessage(string) error
	GetMessage(string) (*dto.TestimonialMessageDTO, error)
	GetMessages(*dto.TestimonialMessageQuery) (*dto.TestimonialMessagesResult, error)
}

func CreateTestimonialMessageDAL() ITestimonialMessageDAL {
	return &mongo.TestimonialMessageDAL{CTX: context.Background(), Collection: getCollection("TestimonialMessages")}
}
