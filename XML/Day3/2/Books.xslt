<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">

<!-- 2-	Display for each book author, title and price in a table. -->

	<!-- Select Path from Root -->
	<xsl:template match="books">
		<h1> A list of books </h1>
		<table bgcolor="yellow" border="2">
			<thead>
				<tr>
					<th>author</th>
					<th>title </th>
					<th>price</th>
				</tr>
			</thead>
				
			<tbody>
				<!-- Select all children of Root -->
				<xsl:for-each select="book">	
					<tr>
						<td>
							<xsl:value-of select="author"></xsl:value-of>
						</td>
						<td>
							<xsl:value-of select="title"></xsl:value-of>
						</td>
						<td>
							<xsl:value-of select="price"></xsl:value-of>
						</td>
						
					</tr>
				</xsl:for-each>
			</tbody>
		</table>

		
		
	
	</xsl:template>




</xsl:stylesheet>


