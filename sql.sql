create table map ( product_id int foreign key(product.id), category_id int foreign(category.id)
select prod.name, categ.name from product prod left join map on prod.id = map.product_id left join category categ on map.category_id = categ.id
