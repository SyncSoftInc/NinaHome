(window.webpackJsonp=window.webpackJsonp||[]).push([[6],{171:function(e,t,n){var content=n(179);content.__esModule&&(content=content.default),"string"==typeof content&&(content=[[e.i,content,""]]),content.locals&&(e.exports=content.locals);(0,n(48).default)("c0e29902",content,!0,{sourceMap:!1})},172:function(e,t,n){var content=n(181);content.__esModule&&(content=content.default),"string"==typeof content&&(content=[[e.i,content,""]]),content.locals&&(e.exports=content.locals);(0,n(48).default)("3646319e",content,!0,{sourceMap:!1})},178:function(e,t,n){"use strict";n(171)},179:function(e,t,n){var o=n(47)(!1);o.push([e.i,'.input-box{position:relative;display:block}.input-box--disabled{cursor:not-allowed}.input-box--disabled .input-box__input{background:#eee}.input-box--disabled .input-box__label{color:#ccc}.input-box--error .input-box__input{border-color:red}.input-box--error .input-box__hint,.input-box--error .input-box__label{color:red}.input-box__input{position:relative;width:100%;height:50px;padding:16px 0 0;border:none;border-bottom:2px solid #ccc;border-radius:0;outline:none;background:#fff;-webkit-appearance:none;-moz-appearance:none;appearance:none;font-size:14px;line-height:32px}.input-box__label{position:absolute;top:0;left:0;display:block;font-size:16px;font-style:normal;line-height:50px;color:#999;transition:.1s}.input-box__hint{line-height:20px}.input-box__input:not([disabled]):focus{border-color:#c1a779}.input-box__input:not([disabled]):focus~.input-box__label{color:#c1a779}.input-box__input:not([disabled]):focus~.input-box__label,.input-box__input:valid~.input-box__label{font-size:12px;line-height:24px}.input-box__input:not([disabled]):focus~.input-box__label:after,.input-box__input:valid~.input-box__label:after{content:" :"}',""]),e.exports=o},180:function(e,t,n){"use strict";n(172)},181:function(e,t,n){var o=n(47)(!1);o.push([e.i,'.text-area{position:relative;display:block}.text-area--disabled{cursor:not-allowed}.text-area--disabled .text-area__input{background:#eee}.text-area--disabled .text-area__label{color:#ccc}.text-area--error .text-area__input{border-color:red}.text-area--error .text-area__hint,.text-area--error .text-area__label{color:red}.text-area__input{position:relative;width:100%;padding:16px 0 0;border:none;border-bottom:2px solid #ccc;border-radius:0;outline:none;background:#fff;-webkit-appearance:none;-moz-appearance:none;appearance:none;font-size:14px;line-height:32px}.text-area__label{position:absolute;top:0;left:0;display:block;width:100%;background:#fff;font-size:16px;font-style:normal;line-height:50px;color:#999;transition:.1s}.text-area__input:not([disabled]):focus{border-color:#c1a779}.text-area__input:not([disabled]):focus~.input-box__label{color:#c1a779}.text-area__input:not([disabled]):focus~.text-area__label,.text-area__input:valid~.text-area__label{font-size:12px;line-height:24px}.text-area__input:not([disabled]):focus~.text-area__label:after,.text-area__input:valid~.text-area__label:after{content:" :"}',""]),e.exports=o},182:function(e,t,n){"use strict";n(170);var o={name:"WidgetInputBox",props:{value:{type:String,default:""},inputLabel:{type:String,required:!0},inputType:{type:String,default:"text",validator:function(e){return-1!==["text","password","email"].indexOf(e)}},length:{type:Number,default:void 0},disabled:{type:Boolean,default:!1},error:{type:Boolean,default:!1},hint:{type:String,default:void 0}}},r=(n(178),n(12)),component=Object(r.a)(o,(function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("label",{staticClass:"input-box",class:{"input-box--disabled":e.disabled,"input-box--error":e.error}},[n("input",{staticClass:"input-box__input",attrs:{required:"",type:e.inputType,maxlength:e.length,disabled:e.disabled},domProps:{value:e.value},on:{input:function(t){return e.$emit("input",t.target.value)},change:function(t){return e.$emit("change",t.target.value)}}}),e._v(" "),n("i",{staticClass:"input-box__label"},[e._v(e._s(e.inputLabel))]),e._v(" "),n("i",{staticClass:"input-box__hint"},[e._v(e._s(e.hint))])])}),[],!1,null,null,null);t.a=component.exports},183:function(e,t,n){"use strict";n(170);var o={name:"WidgetTextArea",props:{value:{type:String,default:""},inputLabel:{type:String,required:!0},rows:{type:Number,default:4},disabled:{type:Boolean,default:!1},error:{type:Boolean,default:!1}}},r=(n(180),n(12)),component=Object(r.a)(o,(function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("label",{staticClass:"text-area",class:{"text-area--disabled":e.disabled,"text-area--error":e.error}},[n("textarea",{staticClass:"text-area__input",attrs:{required:"",rows:e.rows,disabled:e.disabled},domProps:{value:e.value},on:{input:function(t){return e.$emit("input",t.target.value)},change:function(t){return e.$emit("change",t.target.value)}}}),e._v(" "),n("i",{staticClass:"text-area__label"},[e._v(e._s(e.inputLabel))])])}),[],!1,null,null,null);t.a=component.exports},199:function(e,t,n){var content=n(236);content.__esModule&&(content=content.default),"string"==typeof content&&(content=[[e.i,content,""]]),content.locals&&(e.exports=content.locals);(0,n(48).default)("d61d2a44",content,!0,{sourceMap:!1})},235:function(e,t,n){"use strict";n(199)},236:function(e,t,n){var o=n(47)(!1);o.push([e.i,".contact .section-1 .photo-text__photo{margin:0 0 20px}div.result{text-align:center;margin:20px 0 0}div.result--error{color:red}@media(max-width:1020px){.contact__title{margin:40px 0 0;text-align:center}}@media(min-width:1021px){.contact .section-1{width:60%}.contact .section-1 .photo-text__photo-frame{margin:0 auto 20px 0}.contact .section-1 .photo-text__text{padding:0 0 0 30px}.contact .section-1 dd:last-child{margin:10px 0 20px}.contact .section-2{width:40%}}.form__item{margin:0 0 10px}",""]),e.exports=o},260:function(e,t,n){"use strict";n.r(t);n(29);var o=n(185),r=n.n(o),l=n(182),c=n(183),d={name:"Contact",components:{WidgetInputBox:l.a,WidgetTextArea:c.a},data:function(){return{message:{name:"",phone:"",email:"",message:""},error:"",result:"",sending:!1}},methods:{resetForm:function(){this.message={name:"",phone:"",email:"",message:""},this.result="",this.sending=!1},resetError:function(){this.error="",this.result=""},checkEmailFormat:function(){/^\S+@\S+\.\S{2,}$/.test(this.message.email)?this.resetError():(this.error="email",this.result="Email Format Error")},sendMessage:function(){var e=this;this.message.name.length?this.message.phone.length?this.message.email.length?/^\S+@\S+\.\S{2,}$/.test(this.message.email)?this.message.message.length?(this.resetError(),this.sending=!0,r.a.post("https://www.mylightangel.com/api/contact/message",this.message).then((function(t){console.log(t),200===t.status&&(e.result="Successfully."),setTimeout(e.resetForm,4e3)})).catch((function(t){console.dir(t),e.result="Failed. "+t.response.status+" "+t.response.statusText}))):(this.error="message",this.result="Message is required"):(this.error="email",this.result="Email Format Error"):(this.error="email",this.result="Email is required"):(this.error="phone",this.result="Phone is required"):(this.error="name",this.result="Name is required")}}},_=(n(235),n(12)),component=Object(_.a)(d,(function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("main",{staticClass:"main contact"},[n("div",{staticClass:"landscape-flex"},[e._m(0),e._v(" "),n("section",{staticClass:"section-2"},[n("div",{staticClass:"form contact-form"},[n("h3",{staticClass:"form__title"},[e._v("Contact Form")]),e._v(" "),n("div",{staticClass:"form__item"},[n("WidgetInputBox",{attrs:{"input-label":"Your Name",error:"name"===e.error},on:{change:e.resetError},model:{value:e.message.name,callback:function(t){e.$set(e.message,"name",t)},expression:"message.name"}})],1),e._v(" "),n("div",{staticClass:"form__item"},[n("WidgetInputBox",{attrs:{"input-label":"Phone",error:"phone"===e.error},on:{change:e.resetError},model:{value:e.message.phone,callback:function(t){e.$set(e.message,"phone",t)},expression:"message.phone"}})],1),e._v(" "),n("div",{staticClass:"form__item"},[n("WidgetInputBox",{attrs:{"input-label":"Email",error:"email"===e.error},on:{change:e.checkEmailFormat},model:{value:e.message.email,callback:function(t){e.$set(e.message,"email",t)},expression:"message.email"}})],1),e._v(" "),n("div",{staticClass:"form__item"},[n("WidgetTextArea",{attrs:{"input-label":"Message",rows:6,error:"message"===e.error},on:{change:e.resetError},model:{value:e.message.message,callback:function(t){e.$set(e.message,"message",t)},expression:"message.message"}})],1),e._v(" "),e.result.length?n("div",{staticClass:"form__item result",class:{"result--error":e.error.length}},[e._v("\n            "+e._s(e.result)+"\n          ")]):e._e(),e._v(" "),n("div",{staticClass:"form__action"},[n("button",{staticClass:"btn btn__submit",class:{"btn--disabled":e.sending},attrs:{disabled:e.sending},on:{click:e.sendMessage}},[e._v("\n              "+e._s(e.sending?"Sending....":"Send")+"\n            ")])])])])])])}),[function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("section",{staticClass:"section-1 photo-text photo-text--top"},[n("div",{staticClass:"photo-text__flex"},[n("div",{staticClass:"photo-text__photo"},[n("figure",{staticClass:"reverse"},[n("div",{staticClass:"photo-text__photo-frame photo-text__photo-frame--circle"},[n("img",{attrs:{src:"//ssr.azureedge.net/img/2019/08/13/920e1d2db200aa5e4012a2e6df39bed7ca2c3fd8.jpg",srcset:"//ssr.azureedge.net/img/2019/08/13/7761a21b4e99baa700c0459f071dedaa9000897d.jpg 2x",alt:"What happens in our healing session?"}})]),e._v(" "),n("figcaption",{staticClass:"portrait-devices-only"},[e._v("\n              Contact\n            ")])])]),e._v(" "),n("div",{staticClass:"photo-text__text portrait-center"},[n("dl",[n("dt",[e._v("\n              Email\n            ")]),e._v(" "),n("dd",[e._v("\n              nina.jin@icloud.com\n            ")]),e._v(" "),n("dt",[e._v("\n              Phone\n            ")]),e._v(" "),n("dd",[e._v("\n              408-887-7600\n            ")]),e._v(" "),n("dt",[e._v("\n              Healing Session Location\n            ")]),e._v(" "),n("dd",[e._v("\n              San Jose, Calfornia\n              ( Detail Address will be give upon appointment Set up )\n            ")])])])])])}],!1,null,null,null);t.default=component.exports}}]);