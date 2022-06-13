package libs

import (
	"net/smtp"

	"github.com/SyncSoftInc/NinaHome/go/core"
	"github.com/syncfuture/go/u"
)

var (
	_from = "nina@mylightangel.com"
	_pass = "4hqZc$t44H"
)

type EmailSender struct {
	Host string
	Port string
}

func NewEmailSender() *EmailSender {
	return &EmailSender{
		Host: "smtp.zoho.com",
		Port: "587",
	}
}

func (x *EmailSender) Send(subject, mime, body string) (err error) {
	receipt := core.ConfigProvider.GetString("Email.Receipt")

	// auth
	auth := smtp.PlainAuth("", _from, _pass, x.Host)

	// send
	address := x.Host + ":" + x.Port
	message := u.StrToBytes(subject + mime + body)
	err = smtp.SendMail(address, auth, _from, []string{receipt}, message)
	u.LogError(err)

	return
}
