using System;
using System.Collections.Generic;
using System.Text;

namespace XMLHandle
{
    /// <summary>
    /// 用于储存 XML 文档信息
    /// </summary>
    class XMLContent
    {
        public string Name { get; private set; }
        /// <summary>
        /// 成员描述
        /// </summary>
        public List<string> Summary { get; private set; } 
        /// <summary>
        /// 成员参数
        /// </summary>
        public Dictionary<string, string> Param { get; private set; }
        /// <summary>
        /// 成员返回值
        /// </summary>
        public List<string> Return { get; private set; }
        /// <summary>
        /// 成员链接
        /// </summary>
        public List<string> LinkTo { get; private set; }

        public XMLContent(List<string> summary, Dictionary<string, string> param, List<string> @return, List<string> linkTo)
        {
            Summary = summary;
            Param = param;
            Return = @return;
            LinkTo = linkTo;
        }
    }
}
