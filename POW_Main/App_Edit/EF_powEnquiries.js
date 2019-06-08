<script type="text/javascript"> 
var script_powEnquiries = {
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
    ACESupplierID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('SupplierID','');
      var F_SupplierID = $get(sender._element.id);
      var F_SupplierID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_SupplierID.value = p[0];
      F_SupplierID_Display.innerHTML = e.get_text();
    },
    ACESupplierID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('SupplierID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACESupplierID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACESupplierLoginID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('SupplierLoginID','');
      var F_SupplierLoginID = $get(sender._element.id);
      var F_SupplierLoginID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_SupplierLoginID.value = p[0];
      F_SupplierLoginID_Display.innerHTML = e.get_text();
    },
    ACESupplierLoginID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('SupplierLoginID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACESupplierLoginID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_SupplierID: function(sender) {
      var Prefix = sender.id.replace('SupplierID','');
      this.validated_FK_POW_Enquiries_SupplierID_main = true;
      this.validate_FK_POW_Enquiries_SupplierID(sender,Prefix);
      },
    validate_SupplierLoginID: function(sender) {
      var Prefix = sender.id.replace('SupplierLoginID','');
      this.validated_FK_POW_Enquiries_SupplierLoginID_main = true;
      this.validate_FK_POW_Enquiries_SupplierLoginID(sender,Prefix);
      },
    validate_FK_POW_Enquiries_SupplierID: function(o,Prefix) {
      var value = o.id;
      var SupplierID = $get(Prefix + 'SupplierID');
      if(SupplierID.value==''){
        if(this.validated_FK_POW_Enquiries_SupplierID_main){
          var o_d = $get(Prefix + 'SupplierID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SupplierID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_POW_Enquiries_SupplierID(value, this.validated_FK_POW_Enquiries_SupplierID);
      },
    validated_FK_POW_Enquiries_SupplierID_main: false,
    validated_FK_POW_Enquiries_SupplierID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_powEnquiries.validated_FK_POW_Enquiries_SupplierID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
        var o_e = $get('F_SupplierEMailID');
        try{o_e.value = p[3];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_POW_Enquiries_SupplierLoginID: function(o,Prefix) {
      var value = o.id;
      var SupplierLoginID = $get(Prefix + 'SupplierLoginID');
      if(SupplierLoginID.value==''){
        if(this.validated_FK_POW_Enquiries_SupplierLoginID_main){
          var o_d = $get(Prefix + 'SupplierLoginID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SupplierLoginID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_POW_Enquiries_SupplierLoginID(value, this.validated_FK_POW_Enquiries_SupplierLoginID);
      },
    validated_FK_POW_Enquiries_SupplierLoginID_main: false,
    validated_FK_POW_Enquiries_SupplierLoginID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_powEnquiries.validated_FK_POW_Enquiries_SupplierLoginID_main){
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
