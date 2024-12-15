<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" indent="yes"/>

	<!-- Khai báo tham số Data (mã hóa đơn cần tìm kiếm) -->
	<xsl:param name="Data"/>

	<xsl:template match="/">
		<html>
			<head>
				<title>Chi Tiết Hóa Đơn</title>
				<style>
					table { border-collapse: collapse; width: 100%; }
					th, td { border: 1px solid black; padding: 8px; text-align: center; }
					th { background-color: #f2f2f2; }
					h2 { text-align: center; }
				</style>
			</head>
			<body>
				<h2>Danh Sách Chi Tiết Hóa Đơn</h2>
				<table>
					<tr>
						<th>Mã Chi Tiết</th>
						<th>Mã Hóa Đơn</th>
						<th>Mã Thú Cưng</th>
						<th>Số Lượng</th>
						<th>Thành Tiền</th>
					</tr>

					<!-- Lặp qua từng bản ghi Chi Tiết Hóa Đơn theo điều kiện -->
					<xsl:for-each select="NewDataSet/ChiTietHoaDon[maHD = $Data]">
						<tr>
							<td>
								<xsl:value-of select="maChiTiet"/>
							</td>
							<td>
								<xsl:value-of select="maHD"/>
							</td>
							<td>
								<xsl:value-of select="maTC"/>
							</td>
							<td>
								<xsl:value-of select="soLuong"/>
							</td>
							<td>
								<xsl:value-of select="thanhTien"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
