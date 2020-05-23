namespace Wyj.Blog.Blog.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="CategoryAuthorizationProvider" />中对权限的定义.
    ///</summary>
    public static class CategoryPermissions
    {
        /// <summary>
        /// Category权限节点
        ///</summary>
        public const string Node = "Pages.Category";

        /// <summary>
        /// Category查询授权
        ///</summary>
        public const string Query = "Pages.Category.Query";

        /// <summary>
        /// Category创建权限
        ///</summary>
        public const string Create = "Pages.Category.Create";

        /// <summary>
        /// Category修改权限
        ///</summary>
        public const string Edit = "Pages.Category.Edit";

        /// <summary>
        /// Category删除权限
        ///</summary>
        public const string Delete = "Pages.Category.Delete";

        /// <summary>
		/// Category批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.Category.BatchDelete";

        /// <summary>
        /// Category导出Excel
        ///</summary>
        public const string ExportExcel = "Pages.Category.ExportExcel";

        //// custom codes

        //// custom codes end
    }
}