package dto

import (
	"time"

	"github.com/google/uuid"
)

type TestimonialMessageDTO struct {
	BID          string    `bson:"_id,omitempty" json:"_id"`
	ID           uuid.UUID `bson:"ID" json:"id"`
	Name         string    `bson:"Name" json:"name"`
	Message      string    `bson:"Message" json:"message"`
	Type         string    `bson:"Type" json:"tpye"`
	Approved     bool      `bson:"Approved" json:"approved"`
	CreatedOnUtc time.Time `bson:"CreatedOnUtc" json:"createdOnUtc"`
}

type TestimonialMessagesResult struct {
	MsgCode    string                   `json:"msgCode"`
	PageSize   int                      `json:"pageSize"`
	TotalCount int                      `json:"totalCount"`
	Items      []*TestimonialMessageDTO `json:"items"`
}

type TestimonialMessageQuery struct {
	Name          string `json:"name"`
	Approved      bool   `json:"approved"`
	PageSize      int    `json:"pageSize"`
	PageIndex     int    `json:"pageIndex"`
	OrderBy       int    `json:"orderBy"`
	SortDirection string `json:"sortDirection"`
}

func NewTestimonialMessagesResult(totalcount, pageSize int, items []*TestimonialMessageDTO) *TestimonialMessagesResult {
	return &TestimonialMessagesResult{
		TotalCount: totalcount,
		PageSize:   pageSize,
		Items:      items,
	}
}
