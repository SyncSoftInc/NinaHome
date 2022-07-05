package dto

import (
	"time"

	"github.com/google/uuid"
)

type ContactMessageDTO struct {
	BID          string    `bson:"_id,omitempty" json:"_id"`
	ID           uuid.UUID `bson:"ID" json:"id"`
	Name         string    `bson:"Name" json:"name"`
	Phone        string    `bson:"Phone" json:"phone"`
	Email        string    `bson:"Email" json:"email"`
	Message      string    `bson:"Message" json:"message"`
	CreatedOnUtc time.Time `bson:"CreatedOnUtc" json:"createdOnUtc"`
}

type ContactMessagesResult struct {
	MsgCode    string               `json:"msgCode"`
	PageSize   int                  `json:"pageSize"`
	TotalCount int                  `json:"totalCount"`
	Items      []*ContactMessageDTO `json:"items"`
}

type ContactMessageQuery struct {
	Name          string `json:"name"`
	Email         string `json:"email"`
	PageSize      int    `json:"pageSize"`
	PageIndex     int    `json:"pageIndex"`
	OrderBy       int    `json:"orderBy"`
	SortDirection string `json:"sortDirection"`
}

func NewContactMessagesResult(totalcount, pageSize int, items []*ContactMessageDTO) *ContactMessagesResult {
	return &ContactMessagesResult{
		TotalCount: totalcount,
		PageSize:   pageSize,
		Items:      items,
	}
}
