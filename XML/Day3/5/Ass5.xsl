<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">

<!-- 5-	Display CDs in “cd_catalog.xml” in Table sorted according to price in descending order.(data-type=”number”)
-->

	<xsl:template match="CATALOG">
		<h1> My CD Collection </h1>
		<table border="2">
			<thead>
				<tr bgcolor="green">
					<th>TITLE</th>
					<th>ARTIST </th>
					<th>PRICE</th>
				</tr>
			</thead>
				
			<tbody>
				<!-- Select all children of Root -->
				<xsl:for-each select="CD">
					<xsl:sort select="PRICE" data-type="number" order="descending" />
						<tr>
							<td>
								<xsl:value-of select="TITLE"></xsl:value-of>
							</td>
							
							<td>
								<xsl:value-of select="ARTIST"></xsl:value-of>
							</td>
								
							<td>
								<xsl:value-of select="PRICE"></xsl:value-of>
							</td>
								
						</tr>					
				</xsl:for-each>
			</tbody>
		</table>
		
	</xsl:template>

</xsl:stylesheet>
