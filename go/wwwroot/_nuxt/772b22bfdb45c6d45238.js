(window.webpackJsonp=window.webpackJsonp||[]).push([[12,14],{154:function(e,t,n){"use strict";n.r(t),t.default={methods:{triggerCalendly:function(){Calendly.initPopupWidget({url:this.calendlyLink})},openVideoPopup:function(){this.videoPopup.status||(this.videoPopup.status=!0)},closeVideoPopup:function(){this.videoPopup.status=!1}}}},175:function(e,t,n){var content=n(223);"string"==typeof content&&(content=[[e.i,content,""]]),content.locals&&(e.exports=content.locals);(0,n(59).default)("77ece43e",content,!0,{sourceMap:!1})},222:function(e,t,n){"use strict";var o=n(175);n.n(o).a},223:function(e,t,n){(t=n(58)(!1)).push([e.i,".hypnotherapy .section__4 h3{margin:0 0 40px}",""]),e.exports=t},237:function(e,t,n){"use strict";n.r(t);var o={name:"Hypnotherapy",mixins:[n(154).default],data:function(){return{calendlyLink:"https://calendly.com/mylightangel/new-client-free-intro-hypnotherapy-session",carouselIndex:0,factList:[{icon:"HypnosisIsSafe",text:"Hypnosis is safe and effective. It was approved by the American Medical Association\n          in 1958."},{icon:"HypnosisIsANatural",text:"Hypnosis is a natural state that everyone can experience, anyone with an IQ of 70 or\n          greater can be hypnotized."},{icon:"Hypnosishasdouble",text:"Hypnosis has double the success rate of nicotine gum or patches."},{icon:"Youarealways",text:"You are always in control while in hypnosis and can terminate the session at any time."},{icon:"YouCannotBeMadeTo",text:"You cannot be made to do anything against your will. A strong will actually enhances hypnotic effectiveness."},{icon:"HypnosisIsEasyAndBenifits",text:"You cannot be made to do anything against your will. A strong will actually enhances hypnotic effectiveness."}]}},computed:{isLandscape:function(){return document.body.clientWidth>1020},carouselMax:function(){return this.isLandscape?2:5},carouselWidth:function(){return this.isLandscape?-25:-100},carouselPosition:function(){return this.carouselIndex*this.carouselWidth+"%"}},methods:{carouselPrev:function(){this.carouselIndex<this.carouselMax&&(this.carouselIndex+=1)},carouselNext:function(){this.carouselIndex>0&&(this.carouselIndex-=1)}}},r=(n(222),n(9)),component=Object(r.a)(o,(function(){var e=this,t=this,n=t.$createElement,o=t._self._c||n;return o("main",{staticClass:"main hypnotherapy"},[o("section",{staticClass:"section__1 introduction outstanding"},[o("div",{staticClass:"outstanding__wrap flex"},[t._m(0),t._v(" "),o("div",{staticClass:"introduction__content"},[o("h2",[t._v("Hypnotherapy")]),t._v(" "),o("p",[t._v("\n          I am a certified clinical Hypnotherapist. I would love to use this powerful tool to help\n          you to overcome your life challenges. I have seen many miracle transformations with this\n          powerful healing modality. I think Hypnotherapy is a very much under used therapeutic\n          method due to the many misconceptions out there. I am here to open your mind about this\n          powerful therapy and answer all your questions or concerns about it. Please feel free to\n          contact me for a Free Phone consultation about Hypnotherapy.\n        ")]),t._v(" "),t._m(1),t._v(" "),o("p",[o("label",{on:{click:function(){e.calendlyLink="https://calendly.com/mylightangel/new-client-free-intro-hypnotherapy-session"}}},[o("input",{attrs:{type:"radio",name:"calendly",checked:""}}),t._v("\n             \n            "),o("b",[t._v("First Session : Free (60-90 Min.)")])]),t._v(" "),o("br"),t._v(" "),o("label",{on:{click:function(){e.calendlyLink="https://calendly.com/mylightangel/hypnotherapy"}}},[o("input",{attrs:{type:"radio",name:"calendly"}}),t._v("\n             \n            "),o("b",[t._v("Hypnotherapy session with Recording : $125 per session")])])]),t._v(" "),o("a",{staticClass:"btn btn__appointment",on:{click:t.triggerCalendly}},[t._v("\n          Make an Appointment\n        ")]),t._v(" "),o("link",{attrs:{href:"https://assets.calendly.com/assets/external/widget.css",rel:"stylesheet"}}),t._v(" "),o("script",{attrs:{src:"https://assets.calendly.com/assets/external/widget.js",type:"text/javascript"}})])])]),t._v(" "),t._m(2),t._v(" "),t._m(3),t._v(" "),o("section",{staticClass:"section__4 outstanding center"},[o("div",{staticClass:"outstanding__wrap"},[o("h3",[t._v("\n        Some other facts about Hypnosis\n      ")]),t._v(" "),o("div",{staticClass:"carousel"},[o("div",{staticClass:"carousel__controller"},[o("a",{staticClass:"carousel__controller-prev",class:{"carousel__controller--disabled":t.carouselIndex===t.carouselMax},on:{click:t.carouselPrev}}),t._v(" "),o("a",{staticClass:"carousel__controller-next",class:{"carousel__controller--disabled":0===t.carouselIndex},on:{click:t.carouselNext}})]),t._v(" "),o("div",{staticClass:"carousel__wrap"},[o("ul",{staticClass:"carousel__rail",style:{left:t.carouselPosition}},t._l(t.factList,(function(e,n){return o("li",{key:n,staticClass:"carousel__item"},[o("svg",{staticClass:"carousel__icon",attrs:{width:"64",height:"64",viewBox:"0 0 64 64"}},[o("circle",{attrs:{fill:"#C1A779",cx:"32",cy:"32",r:"32"}}),t._v(" "),o("use",{attrs:{href:"/resources/hypnotherapy-icons.svg#"+e.icon}})]),t._v(" "),o("div",{staticClass:"carousel__text"},[t._v("\n                "+t._s(e.text)+"\n              ")])])})),0)])])])]),t._v(" "),t._m(4),t._v(" "),t._m(5)])}),[function(){var e=this.$createElement,t=this._self._c||e;return t("div",{staticClass:"introduction__feature"},[t("img",{attrs:{src:"//ssr.azureedge.net/img/2019/06/15/7fd0140974dc8025989ddf12ad49d459208a3e01.jpg",srcset:"//ssr.azureedge.net/img/2019/06/15/c559f4c0c6b7e28ae55834f99c8dfde227479e5c.jpg 2x",alt:"Hypnotherapy"}})])},function(){var e=this.$createElement,t=this._self._c||e;return t("p",[t("b",[this._v("I offer a Free Introductory Session for new clients. My Hypnotherapy session can be\n            done in person or through Skype.")]),this._v(" I believe to fully understand the client’s problem\n            and concern is the most important step towards healing. In this session, I will listen\n            to your issues and your therapeutic goals, asking many questions to fully understand\n            your issues. This process not only helps me to sufficiently evaluate your health\n            issue, but also provide you with a comprehensive therapeutic plan to facilitate\n            your healing.\n        ")])},function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("section",{staticClass:"section__2 photo-text photo-text--left "},[n("div",{staticClass:"photo-text__flex"},[n("div",{staticClass:"photo-text__photo"},[n("figure",[n("div",{staticClass:"photo-text__photo-frame photo-text__photo-frame--circle"},[n("img",{attrs:{width:"240",height:"240",src:"//ssr.azureedge.net/img/2019/06/15/d4e2fcac49cd9f0654e50dc86518e0b9278b780d.jpg",srcset:"//ssr.azureedge.net/img/2019/06/15/0747a16d754eb0f741aa628c65b03230a83f5c0d.jpg 2x",alt:"What Is Hypnosis?"}})]),e._v(" "),n("figcaption",[e._v("\n            What Is Hypnosis?\n          ")])])]),e._v(" "),n("div",{staticClass:"photo-text__text"},[n("p",[e._v("\n          Hypnosis is the act of guiding someone into the trance state. Trance state refers to:\n        ")]),e._v(" "),n("ul",[n("li",[e._v("A deep state of relaxation.")]),e._v(" "),n("li",[e._v("Hyper focus and concentration.")]),e._v(" "),n("li",[e._v("Increased suggestibility.")])]),e._v(" "),n("p",[e._v("\n          Most of us go in and out of the trance state regularly. If you’ve ever zoned out on your\n          daily commute, fell into a reverie while listening to music, or found yourself immersed\n          in the world of a book or movie, you’ve been in the trance state.\n        ")]),e._v(" "),n("p",[e._v("\n          The idea that hypnotists can take over the minds of their subjects and control their\n          actions is an entirely media-driven myth. In the trance state, you control all of your\n          actions, you can hear everything around you, and you cannot be forced to do something\n          against your will.\n        ")]),e._v(" "),n("div",{staticClass:"photo-text__text-collapsed"},[n("p",[e._v("\n            When you go to a hypnotist for a specific purpose such as smoking cessation, weight\n            reduction, stress relief, eliminating phobias, or trying to help with physical issues\n            such as pain control or performance improvement.  Your therapeutic goal becomes the\n            therapist's objective for you. Our body and mind function as undivided whole, your\n            therapeutic goal is most efficiently accomplished because all parts of your mind and\n            body are working together in the same direction.\n          ")]),e._v(" "),n("p",[e._v("\n            In a hypnotherapy session, clients are conscious; they are awake, participating, and\n            remembering.\n          ")])])])])])},function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("section",{staticClass:"section__3 photo-text photo-text--right"},[n("div",{staticClass:"photo-text__flex"},[n("div",{staticClass:"photo-text__photo"},[n("figure",[n("div",{staticClass:"photo-text__photo-frame photo-text__photo-frame--circle"},[n("img",{attrs:{width:"240",height:"240",src:"//ssr.azureedge.net/img/2019/06/15/9a4818260b0b02b390500685846f8e07b0e947fa.jpg",srcset:"//ssr.azureedge.net/img/2019/06/15/3fb92948d2b8a381c37f992ead586650358bfd63.jpg 2x",alt:"The Experience of Therapeutic Hypnosis"}})]),e._v(" "),n("figcaption",[e._v("\n            The Experience of"),n("br",{staticClass:"landscape-devices-only"}),e._v("\n            Therapeutic Hypnosis\n          ")])])]),e._v(" "),n("div",{staticClass:"photo-text__text"},[n("p",[e._v("\n          Therapeutic hypnosis is an effective way to change unwanted patterns, limiting beliefs,\n          old traumas, fears and negative behaviors. By accessing the subconscious mind through\n          hypnosis, we can change our negative beliefs and habits and replace them with new,\n          healthy and empowering ones. Even illness, pain or irregular body functions can be\n          improved, balanced or eradicated.\n        ")]),e._v(" "),n("p",[e._v("\n          Hypnosis is not sleep, although some people get so relaxed that they may fall into a\n          deeper trance which is not a problem as some part of the subconscious mind continues to\n          listen to the voice of the hypnotherapist, can still follow instructions such as moving\n          a finger, taking a deep breath or awakening themselves when they are asked to do so.\n        ")]),e._v(" "),n("div",{staticClass:"photo-text__text-collapsed"},[n("p",[e._v("\n            The idea that hypnotists can take over the minds of their subjects and control their\n            actions is an entirely media-driven myth. In the trance state, you control all of your\n            actions, you can hear everything around you, and you cannot be forced to do something\n            against your will.\n          ")])])])])])},function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("section",{staticClass:"photo-text photo-text--left"},[n("div",{staticClass:"photo-text__flex"},[n("div",{staticClass:"photo-text__photo"},[n("figure",[n("div",{staticClass:"photo-text__photo-frame photo-text__photo-frame--circle"},[n("img",{attrs:{width:"240",height:"240",src:"//ssr.azureedge.net/img/2019/06/15/8b9c8615059117de3bed5ef6b0bba7fd4ab291e5.jpg",srcset:"//ssr.azureedge.net/img/2019/06/15/0da674cd6cea3e44ab3f15bc48278eafd18db056.jpg 2x",alt:"What happens in our Hypnotherapy session?"}})]),e._v(" "),n("figcaption",[e._v("\n            What happens in our"),n("br",{staticClass:"landscape-devices-only"}),e._v("\n            Hypnotherapy session?\n          ")])])]),e._v(" "),n("div",{staticClass:"photo-text__text"},[n("p",[e._v("\n          In a hypnotherapy session, I spend a great deal of time listening to your issues and\n          your therapeutic goal.  Sometimes a talk therapy is necessary, and will be facilitated\n          for you. This is to help you get clarification on your feelings and agendas of the\n          separate parts of yourselves.\n        ")]),e._v(" "),n("p",[e._v("\n          Once the Hypnosis starts, I will bring you into a light to moderate trance and describe\n          a meditative visualization journey, in such process, I will be weaving in your goals\n          and desired changes. Suggestions for improved behavior are made and anchored in your\n          consciousness, and you emerge from the trance. The changed behavior and new habits are\n          experienced in daily life, sometimes immediately and sometimes gradually. Our session\n          will be recorded, so you can take home a recording to continuously work with your\n          subconscious mind for changes.\n        ")]),e._v(" "),n("div",{staticClass:"photo-text__text-collapsed"},[n("p",[e._v("\n            In a hypnotherapy trance state, you are always in control and will never do or say\n            anything that would conflict with the conscious mind.\n          ")])])])])])},function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("section",{staticClass:"section__5 photo-text photo-text--right"},[n("div",{staticClass:"photo-text__flex"},[n("div",{staticClass:"photo-text__photo"},[n("figure",[n("div",{staticClass:"photo-text__photo-frame photo-text__photo-frame--circle"},[n("img",{attrs:{width:"240",height:"240",src:"//ssr.azureedge.net/img/2019/06/15/8a50ada3b40be7a868b755a461e54b16ae75a801.jpg",srcset:"//ssr.azureedge.net/img/2019/06/15/ec5e2cbd0283c991c22a156f44af38ebbb02baf6.jpg 2x",alt:"What type of health issues hypnotherapy can help with?"}})]),e._v(" "),n("figcaption",[e._v("\n            What type of health"),n("br",{staticClass:"landscape-devices-only"}),e._v("\n            issues hypnotherapy"),n("br",{staticClass:"landscape-devices-only"}),e._v("\n            can help with?\n          ")])])]),e._v(" "),n("div",{staticClass:"photo-text__text"},[n("p",[e._v("\n          The hypnotic trance state is a remarkably flexible tool for Helping mental and physical\n          health problems. Here are just a few ways mental health and medical professionals use\n          hypnotherapy:\n        ")]),e._v(" "),n("p",[e._v("\n          Helping people quit smoking or reduce overeating by focusing their minds and suggesting\n          healthier behavior. Accessing the mind-body link to relieve chronic and acute pain,\n          including during surgery and childbirth, promote fast healing after surgery.\n        ")]),e._v(" "),n("div",{staticClass:"photo-text__text-collapsed"},[n("p",[e._v("\n            Diving deep into the subconscious mind to uncover and treat the root causes of mental\n            health issues:\n          ")]),e._v(" "),n("ul",[n("li",[e._v("Smoking cessation")]),e._v(" "),n("li",[e._v("Weight reduction and Promoting healthy life style")]),e._v(" "),n("li",[e._v("Nail Biting and Other habits Reprogramming")]),e._v(" "),n("li",[e._v("Post-Traumatic Stress and Panic Attacks")]),e._v(" "),n("li",[e._v("Food or Alcohol Addictions, Substance Abuse")]),e._v(" "),n("li",[e._v("Performance Enhancement")]),e._v(" "),n("li",[e._v("Procrastination issues")]),e._v(" "),n("li",[e._v("Memory Improvement and Creativity promotion")]),e._v(" "),n("li",[e._v("Self Esteem and Confidence")]),e._v(" "),n("li",[e._v("Public Speaking and Performance Anxiety")])])])])])])}],!1,null,null,null);t.default=component.exports}}]);