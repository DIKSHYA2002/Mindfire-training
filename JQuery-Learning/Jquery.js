$(document).ready(function () {
    const personObject =
    {
        
    }
    $('form').submit(function (e) {
        e.preventDefault();
        $('input ,select').each(function () {
            if (($(this).attr('type') !== "file") && ($(this).attr('type') !== "checkbox") && ($(this).attr('type') !== "radio")) {
                $(this).css(
                    {
                        'border': `${($(this).val() == '') ? ('2px red solid') : ('2px green solid')}`,
                    }
                )
            }
        });
    }
    )
    $("input ,select").on("change", function () {
        if (($(this).attr('type') !== "file") && ($(this).attr('type') !== "checkbox") && ($(this).attr('type') !== "radio")) {
            $(this).css(
                {
                    'border': `${($(this).val() == '') ? ('2px red solid') : ('2px green solid')}`,
                })
        }
    });
});