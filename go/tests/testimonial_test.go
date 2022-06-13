package tests

import (
	"encoding/json"
	"fmt"
	"strconv"
	"testing"
	"time"

	"github.com/SyncSoftInc/NinaHome/go/dto"
	"github.com/stretchr/testify/assert"
	"github.com/syncfuture/go/u"
)

func Test_Testimonial_Create(t *testing.T) {
	for i := 0; i < 20; i++ {
		dto := &dto.TestimonialMessageDTO{
			Name:         "test_name_" + strconv.Itoa(i),
			Message:      "test_message",
			Type:         "test",
			Approved:     false,
			CreatedOnUtc: time.Now().UTC(),
		}

		err := _testimonialMessageDAL.InsertMessage(dto)
		assert.NoError(t, err)
	}
}

func Test_Testimonial_Approve(t *testing.T) {
	id := "62a77a7ba225d3a97ab089a8"
	err := _testimonialMessageDAL.ApproveMessage(id, false)
	assert.NoError(t, err)
}

func Test_Testimonial_Delete(t *testing.T) {
	id := "62a3c92714972b7acf512e3f"
	err := _testimonialMessageDAL.DeleteMessage(id)
	assert.NoError(t, err)
}

func Test_Testimonial_Get(t *testing.T) {
	q := &dto.TestimonialMessageQuery{
		// Name:      "test_name",
		// Approved:  false,
		PageIndex: 4,
		PageSize:  5,
	}

	r, err := _testimonialMessageDAL.GetMessages(q)
	assert.NoError(t, err)

	json, err := json.Marshal(r)
	fmt.Printf("%v\n", u.BytesToStr(json))
}
