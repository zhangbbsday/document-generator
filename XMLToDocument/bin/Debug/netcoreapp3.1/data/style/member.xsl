<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" doctype-system="about:legacy-compat"/>
	<!--主体-->
	<xsl:template match="member">
		<html>
			<head>
				<meta charset="utf-8"/>
				<title><xsl:value-of select="@name"></xsl:value-of></title>
				<!--<link rel="stylesheet" type="text/css" href="test-style.css"/>
				<script src="test.js"></script>-->
        <style>
          body{
          font-family: "Lucida Console", "微软雅思", arial;
          font-size: 15px;
          background-color: gainsboro;
          }

          .logo{
          float: left;
          text-align: left;
          width: 33.3%;
          }

          .doc-title{
          float: left;
          text-align: center;
          width: 30%;
          }

          .search-box{
          float: left;
          width: 50%;
          }

          input[type="text"]{
          float: right;
          width: 20%;
          padding: 10px;
          margin: 10px;
          }

          .top-menu{
          display: block;
          /* background-color: red; */
          clear: both;
          width: 100%;
          }

          iframe{
          height : 100%;
          }

          .navigation-bar{
          background-color: white;
          overflow: hidden;
          float: left;
          width: 20%;
          height: 600px;
          margin-top: 30px;
          margin-right: 30px;
          max-height: 800px;
          border-color: black;
          border-style: dashed;
          border-width: 1px;
          }

          .doc{
          float: left;
          }

          .doc h2,h3,h4{
          padding: 0 0 10px 0;
          border-bottom: slategray 2px solid;
          }

          span.code code{
          display: block;
          overflow: auto;
          background: #f4f4f4;
          border: 10px solid #eee;
          word-wrap:break-word;
          white-space: pre-wrap;
          }

          span.c code{
          border: 2px solid #eee;
          border-radius: 5px;
          background: #f4f4f4;
          }

          table{
          border-color: black;
          border-style:solid;
          border-width: 1px;
          }

          tr:nth-child(odd){
          background-color: white;
          }

          tr:nth-child(even){
          background-color: #f4f4f4;
          }

          tr td{
          padding: 10px;
          }


          .content{
          display: block;
          clear: both;
          width: 100%;
          }

          .see-link a{
          display: block;
          text-decoration: none;
          }

          .buttom-link{
          width: 100%;
          }

          .copyright{
          float: left;
          margin-left: 30%;
          }

          .version{
          float: left;
          margin-left: 30%;
          }

          .infomation{

          }

          .bottom{
          padding-top: 10px;
          border-top: lightgray 2px solid;
          display: table;
          text-align: center;
          width: 100%;
          }
        </style>
        <script language="JavaScript">

          if (window != top)

          top.location.href = location.href;

        </script>
      </head>
			<body>
				<div class="top-menu">
					<div class="logo">
						<!-- <img src="1.jpg" width="200" height="100"/> -->
					</div>
					<div class="doc-title">
						<span><h1>UIFramework 文档</h1></span>
					</div>
					<!-- <div class="search-box">
						<span>
							<form>
								<input type="text" name="search" placeholder="搜索……"/>
							</form>
						</span>
					</div> -->
				</div>
				<div class="content">
          <div class="navigation-bar">
            <iframe src="navigation.html"></iframe>
          </div>
					<div class="doc">
					<div class="member-title">
						<h1><xsl:value-of select="@name"></xsl:value-of></h1>
					</div>
					<xsl:if test="summary">
						<div class="summary">
							<h2>描述</h2>
							<xsl:apply-templates select="summary"/>
						</div>
					</xsl:if>
					<xsl:if test="param|typeparam">
						<div class="param">
							<h2>参数</h2>
							<table>
								<xsl:apply-templates select="param|typeparam"/>
							</table>		
						</div>
					</xsl:if>
					<xsl:if test="returns">
						<div class="returns">
							<h2>返回值</h2>
							<xsl:apply-templates select="returns"/>
						</div>
					</xsl:if>
					<xsl:if test="example">
						<div class="example">
							<h2>示例</h2>
							<xsl:apply-templates select="example"/>
						</div>
					</xsl:if>
					<xsl:if test="exception">
						<div class="exception">
							<h2>异常</h2>
							<table>
								<xsl:apply-templates select="exception"/>
							</table>
						</div>
					</xsl:if>
					<xsl:if test="remarks">
						<div class="remarks">
							<h2>另注</h2>
							<xsl:apply-templates select="remarks"/>
						</div>
					</xsl:if>
					<xsl:if test="see|seealso">
						<div class="see-link">
							<h2>链接</h2>
							<xsl:apply-templates select="see|seealso"/>
						</div>
					</xsl:if>
				</div>
				</div>
				<div class="bottom">
					<div class="bottom-link">
						<span><a href="http://baidu.com">百度一下</a></span>
					</div>
					<div class="infomation">
						<div class="copyright">
							<span><p>Copyright © HTA</p></span>
						</div>
						<div class="version">
							<span><p>V 1.0</p></span>
						</div>
					</div>
				</div>
			</body>
		</html>
	</xsl:template>
	<!--独立div的-->
	<xsl:template match="summary">
		<p><xsl:apply-templates/></p>
	</xsl:template>
	<xsl:template match="example">
		<p><xsl:apply-templates/></p>
	</xsl:template>	
	<xsl:template match="exception">
		<xsl:for-each select=".">
			<tr>
				<td><xsl:value-of select="@cref"></xsl:value-of></td>
				<td><xsl:apply-templates/></td>
			</tr>
		</xsl:for-each>
	</xsl:template>
	<xsl:template match="remarks">
		<p><xsl:apply-templates/></p>
	</xsl:template>
	<xsl:template match="see">
    <a>
      <xsl:attribute name="href">
        <xsl:value-of select="@cref"/>.html
      </xsl:attribute>
      <xsl:value-of select="@cref"/>
    </a>
		<br/>
	</xsl:template>
	<xsl:template match="seealso">
    <a>
      <xsl:attribute name="href">
        <xsl:value-of select="@cref"/>.html
      </xsl:attribute>
      <xsl:value-of select="@cref"/>
    </a>
		<br/>
	</xsl:template>
	<xsl:template match="param">
		<xsl:for-each select=".">
			<tr>
				<td><xsl:value-of select="@name"></xsl:value-of></td>
				<td><xsl:apply-templates/></td>
			</tr>
		</xsl:for-each>
	</xsl:template>	
	<xsl:template match="typeparam">
		<xsl:for-each select=".">
			<tr>
				<td><xsl:value-of select="@name"></xsl:value-of></td>
				<td><xsl:apply-templates/></td>
			</tr>
		</xsl:for-each>
	</xsl:template>	
	<xsl:template match="returns">
		<p><xsl:apply-templates/></p>
	</xsl:template>		
	<xsl:template match="list">
		<div class="table">
			<table>
				<xsl:for-each select="item">
					<tr>
					<td><xsl:apply-templates select="term"/></td>
					<td><xsl:apply-templates select="description"/></td>
					</tr>
				</xsl:for-each>
			</table>
		</div>
	</xsl:template>
	
	<!--非独立div的-->
	<xsl:template match="paramref">
		<span class="paramref">
			<strong><xsl:value-of select="@name"></xsl:value-of></strong>
		</span>
	</xsl:template>
	<xsl:template match="typeparamref">
		<span class="paramref">
			<strong><xsl:value-of select="@name"></xsl:value-of></strong>
		</span>
	</xsl:template>
	<xsl:template match="para">
		<span class="para">
			<p><xsl:value-of select="."></xsl:value-of></p>
		</span>
	</xsl:template>
	<xsl:template match="code">
		<span class="code">
			<code><xsl:value-of select="."></xsl:value-of></code>
		</span>
	</xsl:template>
	<xsl:template match="c">
		<span class="c">
			<code><xsl:value-of select="."></xsl:value-of></code>
		</span>
	</xsl:template>
	<xsl:template match="term|description">
		<span class="description">
			<xsl:apply-templates/>
		</span>
	</xsl:template>
</xsl:stylesheet>