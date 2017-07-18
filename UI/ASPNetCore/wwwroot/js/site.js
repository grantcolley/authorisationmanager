
$(document).ready(function () {
    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        alert('set ' + $(this).attr('href'));
        localStorage.setItem('activeTab', $(this).attr('href'));
    });

    var activeTab = localStorage.getItem('activeTab');
    if (activeTab) {
        $('[href="' + activeTab + '"]').tab('show');
        alert('get ' + activeTab);
    }
});