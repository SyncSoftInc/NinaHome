package tests

import (
	"bytes"
	"encoding/json"
	"fmt"
	"io"
	"net/http"
	"testing"
	"time"

	"github.com/SyncSoftInc/NinaHome/go/dto"
	"github.com/stretchr/testify/assert"
)

func TestApi_Class_Create(t *testing.T) {
	dto := &dto.ContactMessageDTO{
		Name:  "test_name",
		Phone: "123-456-7890",
		Email: "test@test.com",
		// Type:         "test",
		Message:      "test_message",
		CreatedOnUtc: time.Now().UTC(),
	}
	b, _ := json.Marshal(dto)

	resp, err := http.Post("http://localhost:5006/api/contact/message", "application/json", bytes.NewBuffer(b))
	assert.NoError(t, err)

	defer resp.Body.Close()
	body, err := io.ReadAll(resp.Body)
	assert.NoError(t, err)

	r := ""
	json.Unmarshal(body, &r)
	fmt.Println(r)
}
