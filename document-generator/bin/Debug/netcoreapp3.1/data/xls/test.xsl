<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<!--主体-->
	<xsl:template match="member">
		<html>
			<head>
				<meta charset="utf-8"/>
				<title><xsl:value-of select="@name"></xsl:value-of></title>
			</head>
			<body>
				<div class="top-menu">
					<div class="logo"></div>
					<div class="doc-title">
						<span><h1>我的文档</h1></span>
					</div>
					<div class="search-box"></div>
				</div>
				<div class="navigation-bar">
					<div class="content-list">
						<ul>
							<li>1</li>
							<li>2</li>
							<li>3</li>
						</ul>
					</div>
					<div class="sliderbar"></div>
				</div>
				<div class="content">
					<div class="member-title">
						<xsl:value-of select="@name"></xsl:value-of>
					</div>
					<xsl:if test="summary">
						<div class="summary">
							<h3>描述</h3>
							<xsl:apply-templates select="summary"/>
						</div>
					</xsl:if>
					<xsl:if test="param|typeparam">
						<div class="param">
							<h3>参数</h3>
							<xsl:apply-templates select="param|typeparam"/>
						</div>
					</xsl:if>
					<xsl:if test="returns">
						<div class="returns">
							<h3>返回值</h3>
							<xsl:apply-templates select="returns"/>
						</div>
					</xsl:if>
					<xsl:if test="example">
						<div class="example">
							<h3>示例</h3>
							<xsl:apply-templates select="example"/>
						</div>
					</xsl:if>
					<xsl:if test="exception">
						<div class="exception">
							<h3>异常</h3>
							<xsl:apply-templates select="exception"/>
						</div>
					</xsl:if>
					<xsl:if test="remarks">
						<div class="remarks">
							<h3>另注</h3>
							<xsl:apply-templates select="remarks"/>
						</div>
					</xsl:if>
					<xsl:if test="see|seealso">
						<div class="link">
							<h3>链接</h3>
							<xsl:apply-templates select="see|seealso"/>
						</div>
					</xsl:if>
				</div>
				<div class="bottom">
					<div class="bottom-link"></div>
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
		<div class="table">
			<table border="1">
				<xsl:for-each select=".">
					<tr>
					<td><xsl:value-of select="@cref"></xsl:value-of></td>
					<td><xsl:apply-templates/></td>
					</tr>
				</xsl:for-each>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="remarks">
		<p><xsl:apply-templates/></p>
	</xsl:template>
	<xsl:template match="see">
		<a><xsl:value-of select="@cref"></xsl:value-of></a>
		<br/>
	</xsl:template>
	<xsl:template match="seealso">
		<a><xsl:value-of select="@cref"></xsl:value-of></a>
		<br/>
	</xsl:template>
	<xsl:template match="param">
		<div class="table">
			<table border="1">
				<xsl:for-each select=".">
					<tr>
					<td><xsl:value-of select="@name"></xsl:value-of></td>
					<td><xsl:apply-templates/></td>
					</tr>
				</xsl:for-each>
			</table>
		</div>	
	</xsl:template>	
	<xsl:template match="typeparam">
		<div class="table">
			<table border="1">
				<xsl:for-each select=".">
					<tr>
					<td><xsl:value-of select="@name"></xsl:value-of></td>
					<td><xsl:apply-templates/></td>
					</tr>
				</xsl:for-each>
			</table>
		</div>	
	</xsl:template>	
	<xsl:template match="returns">
		<p><xsl:apply-templates/></p>
	</xsl:template>		
	<xsl:template match="list">
		<div class="table">
			<table border="1">
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