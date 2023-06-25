namespace İkas_Entegrasyonu
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.markaCekBtn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tokenAlBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // markaCekBtn
            // 
            this.markaCekBtn.Location = new System.Drawing.Point(41, 245);
            this.markaCekBtn.Name = "markaCekBtn";
            this.markaCekBtn.Size = new System.Drawing.Size(129, 23);
            this.markaCekBtn.TabIndex = 0;
            this.markaCekBtn.Text = "Token Al ve Marka Çek";
            this.markaCekBtn.UseVisualStyleBackColor = true;
            this.markaCekBtn.Click += new System.EventHandler(this.markaCekBtn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(445, 227);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // tokenAlBtn
            // 
            this.tokenAlBtn.Location = new System.Drawing.Point(332, 245);
            this.tokenAlBtn.Name = "tokenAlBtn";
            this.tokenAlBtn.Size = new System.Drawing.Size(75, 23);
            this.tokenAlBtn.TabIndex = 0;
            this.tokenAlBtn.Text = "Token Al";
            this.tokenAlBtn.UseVisualStyleBackColor = true;
            this.tokenAlBtn.Click += new System.EventHandler(this.tokenAlBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 289);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.tokenAlBtn);
            this.Controls.Add(this.markaCekBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button markaCekBtn;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button tokenAlBtn;
    }
}

