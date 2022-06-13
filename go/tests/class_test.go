package tests

import (
	"encoding/json"
	"fmt"
	"testing"
	"time"

	"github.com/SyncSoftInc/NinaHome/go/dto"
	"github.com/stretchr/testify/assert"
	"github.com/syncfuture/go/u"
)

func Test_Class_Create(t *testing.T) {
	dto := &dto.ClassScheduleMessageDTO{
		Name:         "test_name",
		Phone:        "123-456-7890",
		Email:        "test@test.com",
		Type:         "test",
		Message:      "test_message",
		CreatedOnUtc: time.Now().UTC(),
	}

	err := _classScheduleMessageDAL.InsertMessage(dto)
	assert.NoError(t, err)
}

func Test_Class_Delete(t *testing.T) {
	id := "62a3c92714972b7acf512e3f"
	err := _classScheduleMessageDAL.DeleteMessage(id)
	assert.NoError(t, err)
}

func Test_Class_Get(t *testing.T) {
	// id := "62a3c92714972b7acf512e3f"
	// rs, err := _classScheduleMessageDAL.GetMessage(id)
	// assert.NoError(t, err)

	// json, err := json.Marshal(rs)
	// fmt.Printf("%v\n", u.BytesToStr(json))

	q := &dto.ClassScheduleMessageQuery{
		Name:  "test_name",
		Email: "test@test.com",
	}

	r, err := _classScheduleMessageDAL.GetMessages(q)
	assert.NoError(t, err)

	json, err := json.Marshal(r)
	fmt.Printf("%v\n", u.BytesToStr(json))
}
