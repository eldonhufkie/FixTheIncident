$('#rootwizard').bootstrapWizard({
    'tabClass': 'nav nav-tabs', 'debug': false, onShow: function (tab, navigation, index) {
        console.log('onShow');
    }, onNext: function (tab, navigation, index) {
        console.log('onNext');
    }, onPrevious: function (tab, navigation, index) {
        console.log('onPrevious');
    }, onLast: function (tab, navigation, index) {
        console.log('onLast');
    }, onTabClick: function (tab, navigation, index) {
        console.log('onTabClick');

    }, onTabShow: function (tab, navigation, index) {
        console.log('onTabShow');
        var $total = navigation.find('li').length;
        var $current = index + 1;
        var $percent = ($current / $total) * 100;
        $('#rootwizard .progress-bar').css({ width: $percent + '%' });

        // If it's the last tab then hide the last button and show the finish instead
        if ($current >= $total) {
            $('#rootwizard').find('.pager .next').hide();
            $('#rootwizard').find('.pager .finish').show();
            $('#rootwizard').find('.pager .finish').removeClass('disabled');
        } else {
            $('#rootwizard').find('.pager .next').show();
            $('#rootwizard').find('.pager .finish').hide();
        }
    }
});
$('#rootwizard .finish').click(function () {
    alert('Finished!, Starting over!');
    $('#rootwizard').find("a[href*='rootwizard-tab1']").trigger('click');
});