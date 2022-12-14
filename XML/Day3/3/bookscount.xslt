<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">

<!-- 3-	Display the number of books with review 3.5 and review 4.(bonus -count) -->

	<!-- Select Path from Root -->
	<xsl:template match="books">
		
		<!-- count num of books which review = 3.5 -->
		<xsl:text> Review of 3.5 = </xsl:text>
		<xsl:value-of select="count(book[review='3.5'])"></xsl:value-of>
		
		<!-- count num of books which review = 4 -->
		<xsl:text> Review of 4 = </xsl:text><br></br>
		<xsl:value-of select="count(book[review='4'])"></xsl:value-of>
		
	</xsl:template>




</xsl:stylesheet>


