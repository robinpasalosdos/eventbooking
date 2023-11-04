
<style>
.side{
	background-color: white;
	width: 400px;
	margin-top: 210px;
}
</style>
<nav id="sidebar" class='side'>
		
		<div class="">
				<?php if($_SESSION['login_type'] == 1): ?>

				<a href="index.php?page=home" class="nav-item nav-home" style="background-color: white;"><span class='icon-field'><i class="fa fa-home"></i></span> Home</a>
				<a href="index.php?page=transactions" class="nav-item nav-transactions" style="background-color: white;"><span class='icon-field'><i class="fa fa-list"></i></span> Transaction List</a>	
				<a href="index.php?page=windows" class="nav-item nav-windows" style="background-color: white;"><span class='icon-field'><i class="fa fa-square-full"></i></span> Window List</a>	
				<a href="index.php?page=uploads" class="nav-item nav-uploads" style="background-color: white;"><span class='icon-field'><i class="fa fa-upload"></i></span> Uploads</a>
				<a href="index.php?page=users" class="nav-item nav-users" style="background-color: white;"><span class='icon-field'><i class="fa fa-users"></i></span> Users</a>
				<a href="index.php?page=site_settings" class="nav-item nav-site_settings" style="background-color: white;"><span class='icon-field'><i class="fa fa-cogs"></i></span> Settings</a>
				
			<?php else: ?>
				<a href="index.php?page=home" class="nav-item nav-home"><span class='icon-field'><i class="fa fa-home"></i></span> Home</a>
			<?php endif; ?>
		</div>

</nav>
<script>
	$('.nav-<?php echo isset($_GET['page']) ? $_GET['page'] : '' ?>').addClass('active')
</script>
