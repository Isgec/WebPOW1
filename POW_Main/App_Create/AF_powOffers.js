<script type="text/javascript"> 
var script_powOffers = {
    ACETSID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('TSID','');
      var F_TSID = $get(sender._element.id);
      var F_TSID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_TSID.value = p[0];
      F_TSID_Display.innerHTML = e.get_text();
    },
    ACETSID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('TSID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACETSID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEEnquiryID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('EnquiryID','');
      var F_EnquiryID = $get(sender._element.id);
      var F_EnquiryID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_EnquiryID.value = p[1];
      F_EnquiryID_Display.innerHTML = e.get_text();
    },
    ACEEnquiryID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('EnquiryID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEEnquiryID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_EnquiryID: function(sender) {
      var Prefix = sender.id.replace('EnquiryID','');
      this.validated_FK_POW_Offers_EnquiryID_main = true;
      this.validate_FK_POW_Offers_EnquiryID(sender,Prefix);
      },
    validate_TSID: function(sender) {
      var Prefix = sender.id.replace('TSID','');
      this.validated_FK_POW_Offers_TSID_main = true;
      this.validate_FK_POW_Offers_TSID(sender,Prefix);
      },
    validate_FK_POW_Offers_EnquiryID: function(o,Prefix) {
      var value = o.id;
      var TSID = $get(Prefix + 'TSID');
      if(TSID.value==''){
        if(this.validated_FK_POW_Offers_EnquiryID_main){
          var o_d = $get(Prefix + 'TSID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + TSID.value ;
      var EnquiryID = $get(Prefix + 'EnquiryID');
      if(EnquiryID.value==''){
        if(this.validated_FK_POW_Offers_EnquiryID_main){
          var o_d = $get(Prefix + 'EnquiryID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + EnquiryID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_POW_Offers_EnquiryID(value, this.validated_FK_POW_Offers_EnquiryID);
      },
    validated_FK_POW_Offers_EnquiryID_main: false,
    validated_FK_POW_Offers_EnquiryID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_powOffers.validated_FK_POW_Offers_EnquiryID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_POW_Offers_TSID: function(o,Prefix) {
      var value = o.id;
      var TSID = $get(Prefix + 'TSID');
      if(TSID.value==''){
        if(this.validated_FK_POW_Offers_TSID_main){
          var o_d = $get(Prefix + 'TSID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + TSID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_POW_Offers_TSID(value, this.validated_FK_POW_Offers_TSID);
      },
    validated_FK_POW_Offers_TSID_main: false,
    validated_FK_POW_Offers_TSID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_powOffers.validated_FK_POW_Offers_TSID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
