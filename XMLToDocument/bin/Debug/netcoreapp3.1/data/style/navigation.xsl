<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" doctype-system="about:legacy-compat"/>
	<xsl:template match="Root">
		<html>
			<head>
				<meta charset="utf-8"/>
				<title>导航</title>
        <style>
          body{
						font-family: "Lucida Console", "微软雅思", arial;
						font-size: 15px;
						background-color: gainsboro;
					}
          
          .navigation-title{
          text-align: center;
          margin: 20px 0;
          }

          .navigation-title h3{
          padding: 0 0 10px 0;
          border-bottom: #e6e6e6 1px solid;
          }

          div.content-list ul{
          list-style-type: none;
          padding-left: 0px;
          }

          div.content-list ul ul{
          list-style-type: none;
          padding-left: 30px;
          }

          div.content-list a{
          display: block;
          text-decoration: none;
          line-height: 30px;
          padding-top: 5px;
          padding-bottom: 5px;
          width: 100%;
          word-wrap:break-word;
          white-space: pre-wrap;
          }

          div.content-list a:before{
          content: "@";
          border: #e6e6e6 1px solid;
          border-radius: 100px;
          background-color: greenyellow;
          padding: 5px;
          margin-right: 5px;
          }

          div.content-list a:hover{
          background-color: #555;
          color: white;
          }

          .navigation-bar{
            height: 100%
          }
        </style>
			</head>
			
			<body>
        <div class="navigation-bar">
          <div class="navigation-title">
            <h3>导航栏</h3>
          </div>
          <div class="content-list">
            <ul>
						  <xsl:apply-templates select="namespace"/>
            </ul>
          </div>
          <div class="sliderbar"></div>
        </div>
			</body>
		</html>
	</xsl:template>

  <xsl:template match="namespace">
    <li>
      <span>
        <xsl:value-of select="@name"/>
      </span>

      <ul>
        <xsl:apply-templates select="class"/>
      </ul>
    </li>
  </xsl:template>
  
  <xsl:template match="class">
    <li>
      <span>
        <a>
          <xsl:attribute name="href">
            <xsl:value-of select="@name"/>.html
          </xsl:attribute>
          <xsl:value-of select="@name"/>
        </a>
      </span>

      <ul>
        <xsl:apply-templates select="class"/>
        <xsl:apply-templates select="property"/>
        <xsl:apply-templates select="method"/>
      </ul>
    </li>
  </xsl:template>
  
  <xsl:template match="property">
    <li>
      <span>
        <a>
          <xsl:attribute name="href">
            <xsl:value-of select="@name"/>.html
          </xsl:attribute>
          <xsl:value-of select="@name"/>
        </a>
      </span>
    </li>
  </xsl:template>

  <xsl:template match="method">
    <li>
      <span>
        <a>
          <xsl:attribute name="href">
            <xsl:value-of select="@name"/>.html
          </xsl:attribute>
          <xsl:value-of select="@name"/>
        </a>
      </span>
    </li>
  </xsl:template>
</xsl:stylesheet>