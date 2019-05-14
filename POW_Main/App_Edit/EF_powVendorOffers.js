<script type="text/javascript"> 
var script_powVendorOffers = {
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
    temp: function() {
    }
    }
</script>
