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
				<link rel="stylesheet" type="text/css" href="test-style.css"/>
				<script src="test.js"></script>
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
						<div class="content-list">
							<span class="navigation-title">
								<h3>导航栏</h3>
							</span>
							<ul>
								<li>	
									<a href="#">NameSpace1</a>
									<ul>
										<li>
											<a href="#">Class1</a>
											<ul>
												<a href="#">Method</a>
											</ul>
										</li>
									</ul>
								</li>
								<li>
									<a href="#">NameSpace2</a>
									<ul>
										<a href="#">Class2</a>
										<ul>
											<a href="#">Method</a>
										</ul>
									</ul>
									<ul>
										<a href="#">Class3</a>
									</ul>
								</li>
							</ul>
						</div>
						<div class="sliderbar"></div>
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
		<a href="#"><xsl:value-of select="@cref"></xsl:value-of></a>
		<br/>
	</xsl:template>
	<xsl:template match="seealso">
		<a href="#"><xsl:value-of select="@cref"></xsl:value-of></a>
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