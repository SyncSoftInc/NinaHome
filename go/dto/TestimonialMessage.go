package dto

import (
	"time"
)

type TestimonialMessageDTO struct {
	ID           string    `bson:"_id,omitempty"`
	Name         string    `bson:"Name"`
	Message      string    `bson:"Message"`
	Type         string    `bson:"Type"`
	Approved     bool      `bson:"Approved"`
	CreatedOnUtc time.Time `bson:"CreatedOnUtc,omitempty"`
}

type TestimonialMessagesResult struct {
	MsgCode    string
	PageSize   int
	TotalCount int
	Items      []*TestimonialMessageDTO
}

type TestimonialMessageQuery struct {
	Name          string
	Approved      bool
	PageSize      int
	PageIndex     int
	OrderBy       int
	SortDirection string
}

func NewTestimonialMessagesResult(totalcount, pageSize int, items []*TestimonialMessageDTO) *TestimonialMessagesResult {
	return &TestimonialMessagesResult{
		TotalCount: totalcount,
		PageSize:   pageSize,
		Items:      items,
	}
}
