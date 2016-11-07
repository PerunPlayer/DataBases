<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl" xmlns:students="https://www.w3.org/students">
  <xsl:output method="html" indent="yes"/>

  <xsl:template match="/">
    <html>
      <head>
        <title>I did it!</title>
      </head>
      <body>
        <table>
          <xsl:for-each select="school/students:students/students:student" >
            <ul>
              <li>
                <xsl:value-of select="students:name"></xsl:value-of>
              </li>
              <li>
                <xsl:value-of select="students:gender"></xsl:value-of>
              </li>
              <li>
                <xsl:value-of select="students:birthdate"></xsl:value-of>
              </li>
              <li>
                <xsl:value-of select="students:phone"></xsl:value-of>
              </li>
              <li>
                <xsl:value-of select="students:email"></xsl:value-of>
              </li>
              <li>
                <xsl:value-of select="students:course"></xsl:value-of>
              </li>
              <li>
                <xsl:value-of select="students:specialty"></xsl:value-of>
              </li>
              <li>
                <xsl:value-of select="students:facultynumber"></xsl:value-of>
              </li>
              <li>
                <xsl:value-of select="students:exams"></xsl:value-of>
              </li>
            </ul>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>