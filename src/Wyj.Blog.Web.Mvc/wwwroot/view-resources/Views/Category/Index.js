(function ($) {
    var _categoryService = abp.services.app.category,
        l = abp.localization.getSource('Blog'),
        _$modal = $('#CategoryCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#CategoryTable');

    var _$categoryTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#CategorySearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _categoryService.getAll(filter).done(function (result) {
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
                action: () => _$categoryTable.draw(false)
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
                data: 'categoryName',
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
                        `   <button type="button" class="btn btn-sm bg-secondary edit-category" data-category-id="${row.id}" data-toggle="modal" data-target="#CategoryEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-category" data-category-id="${row.id}" data-category-name="${row.categoryName}">`,
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

        var category = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);
        _categoryService.create(category).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$categoryTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.delete-category', function () {
        var categoryId = $(this).attr("data-category-id");
        var categoryName = $(this).attr('data-category-name');

        deleteCategory(categoryId, categoryName);
    });

    function deleteCategory(categoryId, categoryName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                categoryName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _categoryService.delete({
                        id: categoryId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$categoryTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-category', function (e) {
        var categoryId = $(this).attr("data-category-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Category/EditModal?categoryId=' + categoryId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#CategoryEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });

    $(document).on('click', 'a[data-target="#CategoryCreateModal"]', (e) => {
        $('.nav-tabs a[href="#category-details"]').tab('show');
    });

    abp.event.on('category.edited', (data) => {
        _$categoryTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$categoryTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which === 13) {
            _$categoryTable.ajax.reload();
            return false;
        }
    });
})(jQuery);