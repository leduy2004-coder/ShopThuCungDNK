<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

  <!-- Khai báo tham số Data để nhận mã cần tìm -->
  <xsl:param name="Data"/>

  <!-- Định dạng đầu ra là HTML -->
  <xsl:output method="html" encoding="UTF-8" indent="yes"/>

  <!-- Template gốc áp dụng cho toàn bộ file -->
  <xsl:template match="/">
    <html>
      <head>
        <title>Thông tin Giấy Chứng Nhận</title>
        <link rel="stylesheet" type="text/css" href="css/GiayChungNhan.css"/>

      </head>
      <body>
        <div class="certificate-container">
          <h1>Giấy Chứng Nhận</h1>
          <h2>Thông tin về Giấy Chứng Nhận</h2>

          <!-- Lặp qua từng GiayChungNhan và kiểm tra mã -->
          <xsl:for-each select="NewDataSet/GiayChungNhan[maGiayChungNhan=$Data]">
            <table class="certificate-table">
              <tr>
                <th>Mã Giấy Chứng Nhận</th>
                <td>
                  <xsl:value-of select="maGiayChungNhan"/>
                </td>
              </tr>
              <tr>
                <th>Mã TC</th>
                <td>
                  <xsl:value-of select="maTC"/>
                </td>
              </tr>
              <tr>
                <th>Mã Loại Giấy</th>
                <td>
                  <xsl:value-of select="maLoaiGiay"/>
                </td>
              </tr>
              <tr>
                <th>Ngày Cấp</th>
                <td>
                  <xsl:value-of select="ngayCap"/>
                </td>
              </tr>
              <tr>
                <th>Ngày Hết Hạn</th>
                <td>
                  <xsl:choose>
                    <xsl:when test="ngayHetHan='1900-01-01T00:00:00+07:00'">Không có</xsl:when>
                    <xsl:otherwise>
                      <xsl:value-of select="ngayHetHan"/>
                    </xsl:otherwise>
                  </xsl:choose>
                </td>
              </tr>
              <tr>
                <th>Người Cấp</th>
                <td>
                  <xsl:value-of select="nguoiCap"/>
                </td>
              </tr>
              <tr>
                <th>Chi Tiết</th>
                <td>
                  <xsl:value-of select="chiTiet"/>
                </td>
              </tr>
            </table>
          </xsl:for-each>

          <!-- Hiển thị thông báo nếu không tìm thấy dữ liệu -->
          <xsl:if test="not(NewDataSet/GiayChungNhan[maGiayChungNhan=$Data])">
            <p>
              Không tìm thấy Giấy Chứng Nhận với mã: <xsl:value-of select="$Data"/>
            </p>
          </xsl:if>

          <!-- Footer -->
          <div class="footer">
            <p>
              Được cấp bởi: <xsl:value-of select="NewDataSet/GiayChungNhan/nguoiCap" />
            </p>
            <p>
              Ngày cấp: <xsl:value-of select="NewDataSet/GiayChungNhan/ngayCap" />
            </p>
          </div>
        </div>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>
