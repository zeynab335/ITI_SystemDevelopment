<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
	
	
<!-- 6-	Display CD TITLEs from  “cd_catalog.xml” in table where bgcolor color for CDs
    with price >10 is Red and all the others are green  
-->

	<xsl:template match="CATALOG">
		<h1> My CD Collection </h1>
		<table border="2">
			<thead>
				<tr bgcolor="green">
					<th>TITLE</th>
					<th>ARTIST </th>
				</tr>
			</thead>
				
			<tbody>
				<!-- Select all children of Root -->
				<xsl:for-each select="CD">
						<tr>
							<xsl:variable name="color">
								<xsl:choose>
									<xsl:when test="PRICE>10">
										red
									</xsl:when>
									<xsl:otherwise>
										green
									</xsl:otherwise>
								</xsl:choose>
							</xsl:variable>
							
							<td>
								<xsl:value-of select="TITLE"></xsl:value-of>
							</td>
							
							<td style="background-color : {$color}">
								<xsl:value-of select="ARTIST"></xsl:value-of>
							</td>
								
						</tr>					
				</xsl:for-each>
			</tbody>
		</table>
		
	</xsl:template>


</xsl:stylesheet>
