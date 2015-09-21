<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" 
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:exsl="http://exslt.org/common"
	xmlns:func="http://exslt.org/functions"
	xmlns:head="http://headjs.com"
	extension-element-prefixes="exsl func head">

<xsl:import href="../utilities/page-title.xsl"/>
<xsl:import href="../utilities/navigation.xsl"/>
<xsl:import href="../utilities/date-time.xsl"/>
<xsl:import href="../utilities/headjs.xsl"/>

<xsl:output method="html" omit-xml-declaration="yes" indent="no" />

<xsl:variable name="is-logged-in" select="/data/events/login-info/@logged-in"/>

<xsl:variable name="javascripts">
	<js><xsl:value-of select="concat($workspace, '/assets/javascript/jquery-1.5.min.js')"/></js>
	<js><xsl:value-of select="concat($workspace, '/assets/javascript/functions.js')"/></js>
</xsl:variable>

<xsl:template match="/">
	<xsl:text disable-output-escaping="yes"><![CDATA[<!doctype html>]]></xsl:text>
	<xsl:comment><![CDATA[[if lt IE 7 ]><html lang="en" class="no-js ie6 ]]><xsl:value-of select="concat('page-',$current-page)"/><![CDATA["/><![endif]]]></xsl:comment>
	<xsl:comment><![CDATA[[if IE 7 ]><html lang="en" class="no-js ie7 ]]><xsl:value-of select="concat('page-',$current-page)"/><![CDATA["/><![endif]]]></xsl:comment>
	<xsl:comment><![CDATA[[if IE 8 ]><html lang="en" class="no-js ie8 ]]><xsl:value-of select="concat('page-',$current-page)"/><![CDATA["/><![endif]]]></xsl:comment>
	<xsl:comment><![CDATA[[if IE 9 ]><html lang="en" class="no-js ie9 ]]><xsl:value-of select="concat('page-',$current-page)"/><![CDATA["/><![endif]]]></xsl:comment>
	<xsl:comment><![CDATA[[if (gt IE 9)|!(IE)]><!]]></xsl:comment><html lang="en" class="no-js page-{$current-page}"><xsl:comment><![CDATA[<![endif]]></xsl:comment>
		<head>
			<meta charset="utf-8" />
			<meta name="title" content="{$page-title}" />
			<meta name="tags" content="" />

  <!-- Always force latest IE rendering engine (even in intranet) & Chrome Frame 
       Remove this if you use the .htaccess -->
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>
  <meta name="description" content=""/>
  <meta name="author" content=""/>

  <!--  Mobile viewport optimized: j.mp/bplateviewport -->
  <meta name="viewport" content="width=device-width, initial-scale=1.0"/>

  <!-- Place favicon.ico & apple-touch-icon.png in the root of your domain and delete these references -->
  <link rel="shortcut icon" href="/favicon.ico"/>
  <link rel="apple-touch-icon" href="/apple-touch-icon.png"/>


  <!-- CSS : implied media="all" -->
  <link rel="stylesheet" href="css/style.css?v=2"/>

  <!-- Uncomment if you are specifically targeting less enabled mobile browsers
  <link rel="stylesheet" media="handheld" href="css/handheld.css?v=2">  -->
       		<title><xsl:call-template name="page-title"/></title>
			<link rel="stylesheet" media="screen" href="{$workspace}/assets/css/screen.css" />
                        <xsl:call-template name="css-contextual"/>
			<script src="{$workspace}/assets/javascript/head.min.js"></script>
			<xsl:call-template name="js-contextual"/>
			<xsl:copy-of select="head:js($javascripts)"/>
		</head>
		<body lang="en">
  			<div id="container">
    			<header>

    			</header>
    			<div id="main" role="main">
    			</div>
    			<footer>
    			</footer>
  			</div>
		</body>
	</html>
</xsl:template>
<xsl:template name="css-contextual">
<!-- you can use additional params and stuff in here on a page-by-page basis-->
</xsl:template>
<xsl:template name="js-contextual">
<!-- you can use additional params and stuff in here on a page-by-page basis, good for mixing xsl and js-->
</xsl:template>
<xsl:strip-space elements="*"/>

</xsl:stylesheet>