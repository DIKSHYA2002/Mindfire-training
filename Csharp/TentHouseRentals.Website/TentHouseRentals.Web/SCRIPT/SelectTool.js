
/*select 2 tool for showing images in dropdown*/

function custom_template(obj) {
    var data = $(obj.element).data();
    var text = $(obj.element).text();
    if (data && data['img_src']) {
        img_src = data['img_src'];
        template = $("<div style=\"text-align:center;padding:0.5rem\"><img src=\"" + img_src + "\" style=\"width:30%;height:50px;\"/><p style=\"font-weight: 700;font-size:14pt;text-align:center;\">" + text + "</p></div>");
        return template;
    }
}
var options = {
    'templateSelection': custom_template,
    'templateResult': custom_template,
}
$('#id_select2_example').select2(options);
$('.select2-container--default .select2-selection--single').css({ 'height': '120px' });