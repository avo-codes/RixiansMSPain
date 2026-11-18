import os
from PIL import Image, ImageChops

def mask_image(image_path, mask_path='./mask.png'):
    #load image
    texture = Image.open(image_path).convert("RGBA")
    #load mask
    mask = Image.open(mask_path).convert("RGBA")
    #apply mask and save
    ImageChops.multiply(texture, mask).save(image_path)

def apply_mask_recursively(path):
    for entry in os.listdir(path):
        full_path = os.path.join(path, entry)
        if os.path.isdir(full_path):
            apply_mask_recursively(full_path)
        else:
            if (full_path.endswith('.png')):
                mask_image(full_path)
                print("applied mask to: " + full_path.split("/")[-1])
            else:
                print("skipped: " + full_path)

# Specify the root asset directory path
directory_path = '../HideDetailsMod/artist_assets/'

apply_mask_recursively(directory_path)