package dto

import (
	"time"
)

type ClassScheduleMessageDTO struct {
	ID           string    `bson:"_id,omitempty"`
	Name         string    `bson:"Name"`
	Phone        string    `bson:"Phone"`
	Email        string    `bson:"Email"`
	Type         string    `bson:"Type"`
	Message      string    `bson:"Message"`
	CreatedOnUtc time.Time `bson:"CreatedOnUtc,omitempty"`
}

type ClassScheduleMessagesResult struct {
	MsgCode    string
	PageSize   int
	TotalCount int
	Items      []*ClassScheduleMessageDTO
}

type ClassScheduleMessageQuery struct {
	Name          string
	Email         string
	PageSize      int
	PageIndex     int
	OrderBy       int
	SortDirection string
}

func NewClassScheduleMessagesResult(totalcount, pageSize int, items []*ClassScheduleMessageDTO) *ClassScheduleMessagesResult {
	return &ClassScheduleMessagesResult{
		TotalCount: totalcount,
		PageSize:   pageSize,
		Items:      items,
	}
}
