<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" doctype-system="about:legacy-compat"/>
	<xsl:template match="Root">
		<html>
			<head>
				<meta charset="utf-8"/>
				<title>主入口</title>
				<style>
          body{
          font-family: "Lucida Console", "微软雅思", arial;
          font-size: 15px;
          background-color: gainsboro;
          }

          .doc-title{
          float: left;
          text-align: center;
          width: 30%;
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
					<div class="doc-title">
						<span><h1>UIFramework 文档</h1></span>
					</div>
				</div>
        
				<div class="content">
					<div class="navigation-bar">
            <iframe src="navigation.html"></iframe>
					</div>
					<div class="doc">
						<xsl:apply-templates select="namespace"/>
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
		
	<xsl:template match="namespace">
		<div class="namespace">
			<div class="namespace-title">
				<h3><xsl:value-of select="@name"/></h3>
			</div>
			<xsl:apply-templates select="class"/>
		</div>
	</xsl:template>
		
	<xsl:template match="class">
		<div class="class">
			<div>
        <a>
          <xsl:attribute name="href">
            <xsl:value-of select="@name"/>.html
          </xsl:attribute>
          <xsl:value-of select="@name"/>
        </a>
      </div>
		</div>
	</xsl:template>
</xsl:stylesheet>