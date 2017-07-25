

$(document).ready(function () {    
    $('#userTree').jstree({
        'core': {
            'data': {
                'url': '/Authorisation/GetTree?tab=' + $(this).attr('href'),
                'data': function (node) {
                    return { 'id': node.id };
                }
            }
        }
    });

    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        localStorage.setItem('activeTab', $(this).attr('href'));

        $('#userTree').jstree(true).settings.core.url = '/Authorisation/GetTree?tab=' + $(this).attr('href');
        $('#userTree').jstree(true).refresh();
    });

    var activeTab = localStorage.getItem('activeTab');
    if (activeTab) {
        $('[href="' + activeTab + '"]').tab('show');
    }
});