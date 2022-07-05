package dto

import (
	"time"

	"github.com/google/uuid"
)

type ClassScheduleMessageDTO struct {
	BID          string    `bson:"_id,omitempty" json:"_id"`
	ID           uuid.UUID `bson:"ID" json:"id"`
	Name         string    `bson:"Name" json:"name"`
	Phone        string    `bson:"Phone" json:"phone"`
	Email        string    `bson:"Email" json:"email"`
	Type         string    `bson:"Type" json:"type"`
	Message      string    `bson:"Message" json:"message"`
	CreatedOnUtc time.Time `bson:"CreatedOnUtc" json:"createdOnUtc"`
}

type ClassScheduleMessagesResult struct {
	MsgCode    string                     `json:"msgCode"`
	PageSize   int                        `json:"pageSize"`
	TotalCount int                        `json:"totalCount"`
	Items      []*ClassScheduleMessageDTO `json:"items"`
}

type ClassScheduleMessageQuery struct {
	Name          string `json:"name"`
	Email         string `json:"email"`
	PageSize      int    `json:"pageSize"`
	PageIndex     int    `json:"pageIndex"`
	OrderBy       int    `json:"orderBy"`
	SortDirection string `json:"sortDirection"`
}

func NewClassScheduleMessagesResult(totalcount, pageSize int, items []*ClassScheduleMessageDTO) *ClassScheduleMessagesResult {
	return &ClassScheduleMessagesResult{
		TotalCount: totalcount,
		PageSize:   pageSize,
		Items:      items,
	}
}
