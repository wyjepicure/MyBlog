(function ($) {
    var _tagService = abp.services.app.tag,
        l = abp.localization.getSource('Blog'),
        _$modal = $('#TagCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#TagsTable');

    var _$tagsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#TagsSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _tagService.getAll(filter).done(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function () {
                abp.ui.clearBusy(_$table);
            });
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$tagsTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'tagName',
                sortable: false
            },
            {
                targets: 2,
                data: 'displayName',
                sortable: false
            },

            {
                targets: 3,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-tag" data-tag-id="${row.id}" data-toggle="modal" data-target="#TagEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-tag" data-tag-id="${row.id}" data-tag-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    //_$form.validate({
    //    rules: {
    //        Password: "required",
    //        ConfirmPassword: {
    //            equalTo: "#Password"
    //        }
    //    }
    //});

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var tag = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);
        _tagService.create(tag).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$tagsTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.delete-tag', function () {
        var tagId = $(this).attr("data-tag-id");
        var tagName = $(this).attr('data-user-name');

        deleteTag(tagId, tagName);
    });

    function deleteTag(tagId, tagName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                tagName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _tagService.delete({
                        id: tagId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$tagsTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-tag', function (e) {
        var tagId = $(this).attr("data-tag-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Tag/EditModal?tagId=' + tagId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#TagEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });

    $(document).on('click', 'a[data-target="#TagCreateModal"]', (e) => {
        $('.nav-tabs a[href="#tag-details"]').tab('show');
    });

    abp.event.on('tag.edited', (data) => {
        _$tagsTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$tagsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which === 13) {
            _$tagsTable.ajax.reload();
            return false;
        }
    });
})(jQuery);