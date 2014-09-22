<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h1>Students</h1>
        <div>
          <xsl:for-each select="students">
            <div>
              <p>
                <xsl:value-of select="name"/>
              </p>
              <p>
                <xsl:value-of select="sex"/>
              </p>
              <p>
                <xsl:value-of select="birthDate"/>
              </p>
              <p>
                <xsl:value-of select="email"/>
              </p>
              <p>
                <xsl:value-of select="facultyNumber"/>
              </p>
              <p>
                <xsl:value-of select="enrollment/enrollmentDate"/>
              </p>
              <p>
                <xsl:value-of select="enrollment/enrollmentScore"/>
              </p>
              <div>
                <table>
                  <thead>
                    <tr>
                      <th>Exam Name</th>
                      <th>Exam Score</th>
                    </tr>
                  </thead>
                  <tbody>
                    <xsl:for-each select="exams/exam">
                      <tr>
                        <td>
                          <xsl:value-of select="examName"/>
                        </td>
                        <td>
                          <xsl:value-of select="examScore"/>
                        </td>
                      </tr>
                    </xsl:for-each>
                  </tbody>
                </table>
              </div>
            </div>
          </xsl:for-each>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>