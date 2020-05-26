(function ($) {
    var _blogService = abp.services.app.post,
        l = abp.localization.getSource('Blog'),

        _$table = $('#BlogsTable');

    var _$blogsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#BlogsSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _blogService.getPaged(filter).done(function (result) {
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
                action: () => _$blogsTable.draw(false)
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
                data: 'title',
                sortable: false
            },
            {
                targets: 2,
                data: 'author',
                sortable: false
            },
            {
                targets: 3,
                data: 'url',
                sortable: false
            },
            {
                targets: 4,
                data: 'creationTime',
                sortable: false
            },
            {
                targets: 5,
                data: null,
                sortable: false,

                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [`   <button type="button" class="btn btn-sm bg-primary preview-blog" data-blog-id="${row.id}"  >`,
                    `       <i class="fa fa-fw fa-eye"></i> ${"预览"}`,
                        '   </button>',
                    `   <button type="button" class="btn btn-sm bg-secondary edit-blog" data-blog-id="${row.id}">`,
                    `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                    `   <button type="button" class="btn btn-sm bg-danger delete-blog" data-blog-id="${row.id}" data-blog-name="${row.title}">`,
                    `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>',
                    ].join('');
                }
            }
        ]
    });

    $(document).on('click', '.preview-blog', function () {
        var blogId = $(this).attr("data-blog-id");

        previewBlog(blogId);
    });
    function previewBlog(blogId) {
    }
    $(document).on('click', '.delete-blog', function () {
        var blogId = $(this).attr("data-blog-id");
        var blogName = $(this).attr('data-blog-name');

        deleteBlog(blogId, blogName);
    });

    $(document).on('click', '#writeBlog', function () {
        location.href = 'Blog/Add';
    });

    function deleteBlog(blogId, blogName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                blogName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _blogService.delete({
                        id: blogId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$blogsTable.ajax.reload();
                    });
                }
            }
        );
    }

    $('.btn-search').on('click', (e) => {
        _$blogsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$blogsTable.ajax.reload();
            return false;
        }
    });
})(jQuery);