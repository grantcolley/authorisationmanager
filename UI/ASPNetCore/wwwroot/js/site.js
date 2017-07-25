

$(document).ready(function () {    
    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {

        localStorage.setItem('activeTab', $(this).attr('href'));
        alert($(this).attr('href'));
        $('#userTree').jstree({
            'core': {
                'data': {
                    'url': '/Authorisation/GetTree?' + $(this).attr('href'),
                    'data': function (node) {
                        return { 'id': node.id };
                    }
                }
            }
        });
    });

    var activeTab = localStorage.getItem('activeTab');
    if (activeTab) {
        $('[href="' + activeTab + '"]').tab('show');
        alert("test 2");
    }
});