<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="yes"/>

  <!-- Khai báo tham số Data -->
  <xsl:param name="Data"/>

  <xsl:template match="/">
    <html>
      <head>
        <title>Chi Tiết Người Dùng</title>
        <!-- Liên kết đến tệp CSS cho phong cách hồ sơ -->
        <link rel="stylesheet" type="text/css" href="css/NhanVien.css"/>
      </head>
      <body>
        <div class="profile-container">
          <h2>Hồ Sơ Người Dùng</h2>
          <!-- Hiển thị thông tin người dùng dưới dạng bảng -->
          <div class="profile-info">
            <xsl:for-each select="NewDataSet/NguoiDung[maNV = $Data]">
              <div class="profile-item">
                <label>Mã NV:</label>
                <span>
                  <xsl:value-of select="maNV"/>
                </span>
              </div>
              <div class="profile-item">
                <label>Tên NV:</label>
                <span>
                  <xsl:value-of select="tenNV"/>
                </span>
              </div>
              <div class="profile-item">
                <label>Số Điện Thoại:</label>
                <span>
                  <xsl:value-of select="sdt"/>
                </span>
              </div>
              <div class="profile-item">
                <label>Địa Chỉ:</label>
                <span>
                  <xsl:value-of select="diaChi"/>
                </span>
              </div>
              <div class="profile-item">
                <label>Tài Khoản:</label>
                <span>
                  <xsl:value-of select="tk"/>
                </span>
              </div>
              <div class="profile-item">
                <label>Mật Khẩu:</label>
                <span>
                  <xsl:value-of select="mk"/>
                </span>
              </div>
              <div class="profile-item">
                <label>Mã Role:</label>
                <span>
                  <xsl:value-of select="maRole"/>
                </span>
              </div>
            </xsl:for-each>
          </div>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
