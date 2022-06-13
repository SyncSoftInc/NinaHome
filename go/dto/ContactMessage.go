package dto

import (
	"time"
)

type ContactMessageDTO struct {
	ID           string    `bson:"_id,omitempty"`
	Name         string    `bson:"Name"`
	Phone        string    `bson:"Phone"`
	Email        string    `bson:"Email"`
	Message      string    `bson:"Message"`
	CreatedOnUtc time.Time `bson:"CreatedOnUtc,omitempty"`
}

type ContactMessagesResult struct {
	MsgCode    string
	PageSize   int
	TotalCount int
	Items      []*ContactMessageDTO
}

type ContactMessageQuery struct {
	Name          string
	Email         string
	PageSize      int
	PageIndex     int
	OrderBy       int
	SortDirection string
}

func NewContactMessagesResult(totalcount, pageSize int, items []*ContactMessageDTO) *ContactMessagesResult {
	return &ContactMessagesResult{
		TotalCount: totalcount,
		PageSize:   pageSize,
		Items:      items,
	}
}
